using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public KeyCode switchWeapons;
    public List<BaseWeapon> ownedWeapons;
    private int weaponIndex = 0;
    public BaseWeapon equippedWeapon;

    public int ammo;
    public float reloadTimer;
    public float fireRateTimer;

    public Transform firePoint;
    
    void Start()
    {
        if (ownedWeapons.Count != 0)
        {
            equippedWeapon = ownedWeapons[weaponIndex];
        }
    }

    void Update()
    {
        
    }
    
    void HandleFiring()
    {
        if (Input.GetButtonDown("Fire1") && equippedWeapon.weaponAttributes.ammoCount > 0 && fireRateTimer < Time.time)
        {
            Debug.Log("Firing");
            Fire();
        }
    }

    void HandleWeaponSwitch()
    {
        if (weaponIndex >= ownedWeapons.Count)
        {
            weaponIndex = weaponIndex % ownedWeapons.Count;
        }
        equippedWeapon = ownedWeapons[weaponIndex];
        this.weaponIndex++;
    }

    void Fire()
    {
        if (equippedWeapon.weaponAttributes.ammoCount == 0) return;
        equippedWeapon.weaponAttributes.ammoCount--;
        if (!(fireRateTimer < Time.time)) return;
        HandleFireRate(equippedWeapon.weaponAttributes.fireRate);
        equippedWeapon.weaponAttributes.projectile.SetRange(10f);
        Instantiate(equippedWeapon.weaponAttributes.projectile.gameObject, firePoint.position, Quaternion.identity);

    }

    private void HandleReload(float reloadTime)
    {
        reloadTimer = Time.time + reloadTime;
    }

    private void HandleFireRate(float fireRate)
    {
        fireRateTimer = Time.time + fireRate;
    }
}
