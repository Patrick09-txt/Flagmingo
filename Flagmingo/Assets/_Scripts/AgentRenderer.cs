using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    protected SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(InputAction.CallbackContext context)
    {
        Vector2 pointerInput = context.ReadValue<Vector2>();

        // Finds the direction from the player to the pointer.
        var dir = (Vector3)pointerInput - transform.position;
        
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
}
