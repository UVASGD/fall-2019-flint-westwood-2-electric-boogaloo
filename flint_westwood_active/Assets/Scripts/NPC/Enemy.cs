using System;
using NPC.Spawning.Data;
using UnityEngine;

namespace NPC
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        public EnemyAttributes enemyAttributes;

        private void Start()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage()
        {
            Debug.Log("ouch");
            enemyAttributes.enemyHealth--;
        }
    }
}