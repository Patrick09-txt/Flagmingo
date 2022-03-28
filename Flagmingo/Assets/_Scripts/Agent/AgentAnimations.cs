using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    protected Animator agentAnimator;

    private void Awake()
    {
        agentAnimator = GetComponent<Animator>();
    }

    public void SetWalkAnim(bool value)
    {
        agentAnimator.SetBool("Walk", value);
    }

    public void AnimatePlayer(float velocity)
    {
        SetWalkAnim(velocity > 0);
    }
}
