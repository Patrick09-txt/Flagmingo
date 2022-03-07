using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    // PROPERTIES
    [SerializeField] protected GameObject muzzle;

    [SerializeField] protected int _ammo = 10;
    [SerializeField] protected WeaponDataSO weaponData;

    public int Ammo
    {
        get { return _ammo; }
        set 
        {
            _ammo = Mathf.Clamp(value, 0, weaponData.ammoCapacity);
        }
    }

    public bool ammoFull { get => Ammo >= weaponData.ammoCapacity; }

    protected bool isShooting = false;

    [SerializeField] protected bool reloadCoroutine = false;

    // UNITY EVENTS
    [SerializeField] public UnityEvent OnShoot;
    [SerializeField] public UnityEvent OnShootNoAmmo;

    // METHODS
    private void Start()
    {
        Ammo = weaponData.ammoCapacity;
    }

    public void TryShooting()
    {
        isShooting = true;
        Debug.Log("Trying to shoot!!");
    }

    public void StopShooting()
    {
        isShooting = false;
        Debug.Log("STOPPED SHOOTING!!");
    }

    public void Reload(int ammo)
    {
        Ammo += ammo;
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && reloadCoroutine == false)
        {
            if (Ammo > 0)
            {
                Ammo--;
                OnShoot?.Invoke();
                for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishedShooting();
        }
    }

    private void FinishedShooting()
    {
        StartCoroutine(DelayNextShotCoroutine());

        if (weaponData.AutomaticFire == false)
        {
            isShooting = false;
        }
    }

    protected IEnumerator DelayNextShotCoroutine()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
        Debug.Log("Shooting A Bullet");
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var newBullet = Instantiate(weaponData.BulletData.BulletPrefab, position, rotation);
        newBullet.GetComponent<Bullet>().BulletData = weaponData.BulletData;
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }
}
