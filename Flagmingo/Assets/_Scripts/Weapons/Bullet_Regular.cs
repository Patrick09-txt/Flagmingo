using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Regular : Bullet
{
    protected Rigidbody2D rigidbody2D;

    [HideInInspector] public GameObject PlayerOrigin;

    public override BulletDataSO BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if (rigidbody2D != null && BulletData != null)
        {
            rigidbody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hittable = collision.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);

        

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle();
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HitEnemy();
            gameObject.SetActive(false);
        }
        
        //Destroy(gameObject);
    }

    private void HitEnemy()
    {
        Debug.Log(Colorize.Attack("Hit enemy"));
    }

    private void HitObstacle()
    {
        Debug.Log(Colorize.Attack("Hit obstacle"));
    }

    public IEnumerator TimerToDisable()
    {
        yield return new WaitForSeconds(2);

        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}
