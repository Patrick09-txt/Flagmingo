using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/BulletData")]
public class BulletDataSO : ScriptableObject
{
    [SerializeField] public GameObject BulletPrefab;
    [SerializeField] [Range(1, 100)] public float BulletSpeed = 30;
    [SerializeField] [Range(1, 10)] public int Damage = 1;
    [SerializeField] [Range(0, 100)] public float Friction = 0;
    [SerializeField] public bool Bounce = false;
    [SerializeField] public bool GoThroughHittable = false;
    [SerializeField] public bool IsRaycast = false;
    [SerializeField] public GameObject ImpactObstaclePrefab;
    [SerializeField] public GameObject ImpactEnemyPrefab;
    [SerializeField] [Range(1, 20)] public float KnockbackPower = 5;
    [SerializeField] [Range(0.1f, 1f)] public float KnockbackDelay = 0.1f;
}
