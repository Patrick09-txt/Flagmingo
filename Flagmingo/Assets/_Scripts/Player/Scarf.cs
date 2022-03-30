using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Scarf : MonoBehaviour
{
    protected Animator scarfAnimator;

    [SerializeField] protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        scarfAnimator = GetComponent<Animator>();
    }

    public void SetWalkAnim(bool value)
    {
        scarfAnimator.SetBool("Walk", value);
    }

    public void AnimatePlayer(float velocity)
    {
        SetWalkAnim(velocity > 0);
    }

    public void Flip(bool flip)
    {
        if (flip)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void SetColor(PlayerJoinController joinController)
    {
        spriteRenderer.color = joinController.PlayerColors[0];
        
        joinController.PlayerColors.RemoveAt(0);
        joinController.PlayerColors.TrimExcess();
    }
}
