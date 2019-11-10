using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName="Scriptable Objects/Create New Weapon", order=1)]
public class Weapon : ScriptableObject
{
    public int numBullets;
    public float weaponRange;
    public Sprite weaponImage;
}
