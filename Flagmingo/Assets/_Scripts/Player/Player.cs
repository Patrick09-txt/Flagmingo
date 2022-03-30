using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerNumber
{
    One,
    Two,
    Three,
    Four
}
public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField] public int Health { get; private set; }

    [field: SerializeField] public UnityEvent OnDie { get; set; }
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }

    public PlayerNumber PlayerNumber;

    private bool dead = false;

    public void GetHit(int damage, GameObject damageDealer)
    {
        Debug.Log(Colorize.Player("Player got hit"));

        if (!dead)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                Debug.Log(Colorize.Player("Player dieaded"));

                OnDie?.Invoke();
                dead = true;

                Destroy(gameObject, 0.25f);
            }
        }
    }
}
