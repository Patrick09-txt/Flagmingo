using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected float desiredAngle;

    [SerializeField] protected WeaponRenderer weaponRenderer;
    [SerializeField] protected Weapon weapon;

    private void Awake()
    {
        AssignWeapon();
    }

    private void AssignWeapon()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPos)
    {
        var aimDir = (Vector3)pointerPos - transform.position;
        // Neat math!
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

        AdjustWeaponRendering();

        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }

    protected void AdjustWeaponRendering()
    {
        if (weaponRenderer != null)
        {
            weaponRenderer.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
            weaponRenderer.RenderBehindPlayer(desiredAngle < 180 && desiredAngle > 0);
        }
    }

    public void Shoot()
    {
        // This instead of just "weapon?." because we need to remove the weapons at runtime
        if (weapon != null)
        {
            weapon.TryShooting();
        }
    }

    public void StopShooting()
    {
        // This instead of just "weapon?." because we need to remove the weapons at runtime
        if (weapon != null)
        {
            weapon.StopShooting();
        }
    }
}
