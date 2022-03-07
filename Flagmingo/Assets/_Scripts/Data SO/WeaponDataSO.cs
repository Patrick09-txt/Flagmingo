using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] public BulletDataSO BulletData;

    [Header("General Settings")]
    [SerializeField] [Range(1, 100)] public int ammoCapacity = 100;
    [SerializeField] public bool AutomaticFire = false;
    [SerializeField] [Range(0.1f, 2f)] public float WeaponDelay = 0.1f;
    [SerializeField] [Range(0, 10)] public float SpreadAngle = 5;

    [Header("Multi Shot Settings")]
    [SerializeField] private bool multiBulletShot = false;
    [SerializeField] [Range(1, 10)] private int multiShotCount = 1;

    internal int GetBulletCountToSpawn()
    {
        if (multiBulletShot)
        {
            return multiShotCount;
        }
        else return 1;
    }
}
