using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected EnemyAIBrain enemyBrain;
    protected bool waitBeforeNextAttack;

    [field: SerializeField] public float AttackDelay { get; private set; } = 1;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyAIBrain>();
    }

    public abstract void Attack(int damage);

    protected IEnumerator WaitBeforeNextAttack()
    {
        waitBeforeNextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        waitBeforeNextAttack = false;
    }

    protected GameObject GetTarget()
    {
        return enemyBrain.Target;
    }
}
