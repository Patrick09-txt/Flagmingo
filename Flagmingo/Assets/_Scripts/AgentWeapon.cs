using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public virtual void AimWeapon(InputAction.CallbackContext context)
    {
        Vector2 pointerPos = context.ReadValue<Vector2>();
        //var aimDir = new Vector3();

        var aimDir = ConvertScreenToWorldPoint((Vector3)pointerPos) - transform.position;

        //if (context.GetType() == typeof(Mouse))
        //{
        //    aimDir = AimWeaponMouse((Vector3)pointerPos) - transform.position;
        //}
        //else
        //{
        //    aimDir = (Vector3)pointerPos - transform.position;
        //}

        // Neat math!
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

        AdjustWeaponRendering();

        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }

    private Vector3 ConvertScreenToWorldPoint(Vector3 pointerPos)
    {
        return gameObject.GetComponentInParent<PlayerReferences>().Camera.ScreenToWorldPoint(pointerPos);
    }

    protected void AdjustWeaponRendering()
    {
        if (weaponRenderer != null)
        {
            weaponRenderer.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
            weaponRenderer.RenderBehindPlayer(desiredAngle < 180 && desiredAngle > 0);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (weapon != null)
        {
            if (context.action.triggered)
            {
                // This instead of just "weapon?." because we need to remove the weapons at runtime
                if (weapon != null)
                {
                    weapon.TryShooting();
                }
            }
            if (context.canceled)
            {
                weapon.StopShooting();
            }
        }
    }

    //public void StopShooting()
    //{
    //    // This instead of just "weapon?." because we need to remove the weapons at runtime
    //    if (weapon != null)
    //    {
    //        weapon.StopShooting();
    //    }
    //}
}
