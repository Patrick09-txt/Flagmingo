using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField] public int Health { get; private set; }

    [field: SerializeField] public UnityEvent OnDie { get; set; }
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }

    private bool dead = false;

    public void GetHit(int damage, GameObject damageDealer)
    {
        Debug.Log("Player got hit");

        if (!dead)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                Debug.Log("Player diead");

                OnDie?.Invoke();
                dead = true;

                Destroy(gameObject, 0.25f);
            }
        }
    }
}
