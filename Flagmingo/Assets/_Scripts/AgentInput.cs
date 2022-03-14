using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerInput
{
    PlayerOne,
    PlayerTwo
}
public class AgentInput : MonoBehaviour, IAgentInput
{
    private Camera mainCamera;
    private bool fireButtonDown = false;

    [Header("Inputs")]
    public PlayerInput PlayerInput;

    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField] public UnityEvent<Vector2> OnPointerPositionChange { get; set; }
    [field: SerializeField] public UnityEvent OnFire { get; set; }
    [field: SerializeField] public UnityEvent OnFireStop { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    /*
     * 
    // Update is called once per frame
    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void GetPointerInput()
    {
        // A little safety in case the camera near clip plane is messing with the mouse pointer
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;

        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousePos);
        OnPointerPositionChange?.Invoke(mouseInWorldSpace);
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireButtonDown == false)
            {
                fireButtonDown = true;
                OnFire?.Invoke();
            }
        }
        else
        {
            if (fireButtonDown == true)
            {
                fireButtonDown = false;
                OnFireStop?.Invoke();
            }
        }
    }

    */
}
