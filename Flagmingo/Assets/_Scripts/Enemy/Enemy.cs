using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent
{
    [field: SerializeField] public EnemyDataSO EnemyData { get; set; }
    [field: SerializeField] public int Health { get; private set; } = 2;

    [field: SerializeField] public EnemyAttack EnemyAttack { get; private set; }

    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    private bool dead = false;

    private void Awake()
    {
        if(EnemyAttack == null)
        {
            EnemyAttack = GetComponent<EnemyAttack>();
        }
    }

    private void Start()
    {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!dead)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                dead = true;
                OnDie?.Invoke();
                Destroy(gameObject, 0.55f);
            }
        }
    }

    public void PerformAttack()
    {
        if(!dead)
        {
            EnemyAttack.Attack(EnemyData.Damage);
        }
    }
}
