using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamager
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DealDamage(IDamagable objectToDamage)
    {
        objectToDamage.TakeDamage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MonoBehaviour[] collisionList = other.gameObject.GetComponents<MonoBehaviour>();
        // ths code is slow but w/e
        foreach (var mb in collisionList)
        {
            if (mb is IDamagable)
            {
                IDamagable damagableItem = (IDamagable) mb;
                DealDamage(damagableItem);
            }
        }
    }
}
