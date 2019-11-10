using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prop", menuName="Scriptable Objects/Props", order=2)]
public class Prop : ScriptableObject
{
   [Header("Prop Base Attributes")]
   public string propName;
   public string propDesc;
   [Header("Prop Value Attributes")]
   public float propPrice;
   public float propConditon;
   public float damageDealt;
   [Header("Prop Conditonal Attributes")]
   public bool canDamageEnemies;
   public bool isPurchasable;
   public bool isPlacable;
   [Header("Prop Inventory Linking")]
   public Sprite propSprite;
   
}