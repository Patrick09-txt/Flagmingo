using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private InputControlScheme inputScheme;
    InputDevice device;

    protected SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        inputScheme = input.controlSchemes[0];
    }

    public void FaceDirection(InputAction.CallbackContext context)
    {
        Vector2 pointerPos = context.ReadValue<Vector2>();

        Debug.Log("Control Scheme: " + inputScheme.name);

        if (inputScheme.name == "Keyboard&Mouse")
        { 
            // Finds the direction from the player to the pointer.
            var dir = ConvertScreenToWorldPoint((Vector3)pointerPos) - transform.position;
            // If the pointer is to the left of up, result is positive and vice versa. IDK, math I guess...
            var result = Vector3.Cross(Vector2.up, dir);

            if (result.z > 0)
            {
                sr.flipX = false;
            }

            else if (result.z < 0)
            {
                sr.flipX = true;
            }
        }
        else if (inputScheme.name == "Gamepad")
        {
            // Finds the direction from the player to the pointer.
            var dir = pointerPos.x;
            Debug.Log(dir);

            if (dir > 0)
            {
                sr.flipX = false;
            }

            else if (dir < 0)
            {
                sr.flipX = true;
            }
        }
        
    }

    private Vector3 ConvertScreenToWorldPoint(Vector3 pointerPos)
    {
        return gameObject.GetComponentInParent<PlayerReferences>().Camera.ScreenToWorldPoint(pointerPos);
    }
}
