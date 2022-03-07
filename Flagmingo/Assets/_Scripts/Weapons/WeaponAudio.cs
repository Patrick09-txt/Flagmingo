using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField] protected AudioClip shootBulletClip = null, noAmmoClip = null;

    public void PlayShootSound()
    {
        PlayClip(shootBulletClip);
    }

    public void PlayNoAmmoSound()
    {
        PlayClip(noAmmoClip);
    }
}
