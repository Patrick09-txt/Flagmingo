using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    protected SpriteRenderer sr;

    [field: SerializeField] public UnityEvent<bool> OnFlip { get; set; }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(InputAction.CallbackContext context)
    {
        Vector2 pointerPos = context.ReadValue<Vector2>();

        // Måden vi ser hvilket control scheme der bruges. Det er virkelig grimt, men det virker
        // En bedre måde ville være at tjekke "Control Scheme" men jeg kunne ikke få det til at virke.
        if (context.control.name == "position")
        { 
            // Finds the direction from the player to the pointer.
            var dir = ConvertScreenToWorldPoint((Vector3)pointerPos) - transform.position;
            // If the pointer is to the left of up, result is positive and vice versa. IDK, math I guess...
            var result = Vector3.Cross(Vector2.up, dir);

            if (result.z > 0)
            {
                sr.flipX = false;
                OnFlip?.Invoke(false);
            }

            else if (result.z < 0)
            {
                sr.flipX = true;
                OnFlip?.Invoke(true);
            }
        }
        else if (context.control.name == "rightStick")
        {
            // Finds the direction from the player to the pointer.
            var dir = pointerPos.x;

            if (dir > 0)
            {
                sr.flipX = true;
                OnFlip?.Invoke(true);
            }

            else if (dir < 0)
            {
                sr.flipX = false;
                OnFlip?.Invoke(false);
            }
        }
    }

    private Vector3 ConvertScreenToWorldPoint(Vector3 pointerPos)
    {
        return gameObject.GetComponentInParent<PlayerReferences>().Camera.ScreenToWorldPoint(pointerPos);
    }
}
