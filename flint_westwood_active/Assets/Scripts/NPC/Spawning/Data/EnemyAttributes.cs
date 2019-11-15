using UnityEngine;

namespace NPC.Spawning.Data
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "Enemy Attributes", order = 0)]
    public class EnemyAttributes : ScriptableObject
    {
        public EnemyType enemyType;
        public string enemyName;
        public string enemyDescription;
        public Sprite enemySprite;
        public GameObject enemyPrefab;
        public int enemyHealth;
        public int enemyDamageAmount;
        public float enemyMoveSpeed;
        public float enemyAttackTime;
    }
}