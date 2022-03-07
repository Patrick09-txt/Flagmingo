using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    // Events
    [SerializeField] public UnityEvent<float> OnVelocityChange;

    protected Rigidbody2D rb;

    [field: SerializeField] public MovementDataSO MovementData { get; set; }

    protected float currentVelocity;
    protected Vector2 moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        // This makes sure that deceleration works.
        if (movementInput.magnitude > 0)
        {
            moveDirection = movementInput.normalized;
        }

        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deceleration * Time.deltaTime;
        }

        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        rb.velocity = currentVelocity * moveDirection.normalized;
    }
}
