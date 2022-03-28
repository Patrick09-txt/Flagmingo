using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStepAudio : AudioPlayer
{
    [SerializeField] protected AudioClip stepClip;

    public void PlayStepSound()
    {
        PlayClipWithPitchVariation(stepClip);
    }
}
