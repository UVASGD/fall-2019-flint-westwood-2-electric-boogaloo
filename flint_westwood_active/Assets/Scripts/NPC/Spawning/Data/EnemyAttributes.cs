using UnityEngine;

namespace NPC.Spawning.Data
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "Enemy Attributes", order = 0)]
    public class EnemyAttributes : ScriptableObject
    {
        public EnemyType enemyType;
    }
}