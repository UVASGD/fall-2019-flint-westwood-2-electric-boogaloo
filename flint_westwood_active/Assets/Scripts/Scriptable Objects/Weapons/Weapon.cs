using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName="Scriptable Objects/Weapons", order=1)]
public class Weapon : ScriptableObject
{
    public int numBullets;
    public float weaponRange;
}
