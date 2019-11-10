using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName="Scriptable Objects/Weapons", order=1)]
public class Weapon : ScriptableObject
{
    [Header("Base Weapon Information")]
    public string mame;
    public string desc;
    [Header("Weapon Values")]
    public int ammoCount;
    public float damage;
    public float reloadSpeed;
    public float fireRate;
    public float range;
    public float price;
    [Header("Weapon Conditional Attributes")]
    public bool isUpgradable;
    public UpgradeType upgradeType;
    [Header("Weapon Inventory Link")] 
    public Sprite weaponSprite;
    [Header("Weapon GameObjects")] 
    public BaseProjectile projectile;
    public AudioClip fireSound;
    public AudioClip reloadSound;
    public AudioClip outOfAmmoSound;

}
