using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    // Events
    [SerializeField] public UnityEvent<float> OnVelocityChange;

    protected Rigidbody2D rb;

    [field: SerializeField] public MovementDataSO MovementData { get; set; }

    protected Vector2 currentVelocity;
    protected float horizontal;
    protected float vertical;
    
    private bool hasFlag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;

        if (hasFlag)
        {
            currentVelocity = CalculateSpeed(MovementData.flagSpeed);
        }
        else
        {
            currentVelocity = CalculateSpeed(MovementData.maxSpeed);
        }

        //StartCoroutine(CheckInput(context));
    }

    private Vector2 CalculateSpeed(float speed)
    {
        return new Vector2(horizontal * speed, vertical * speed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(rb.velocity.magnitude);
        rb.velocity = currentVelocity;
    }

    //private IEnumerator CheckInput(InputAction.CallbackContext context)
    //{
    //    yield return null;
    //    horizontal = context.ReadValue<Vector2>().x;
    //    vertical = context.ReadValue<Vector2>().y;

    //    currentVelocity = CalculateSpeed();
    //}

    public void PickedUpFlag()
    {
        hasFlag = true;
    }

    public void DroppedFlag()
    {
        hasFlag = false;
    }
}
