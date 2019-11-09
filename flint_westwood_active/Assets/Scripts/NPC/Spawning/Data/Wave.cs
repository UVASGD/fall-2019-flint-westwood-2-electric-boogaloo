using System.Collections;
using System.Collections.Generic;
using NPC;
using NPC.Spawning.Data;
using UnityEngine;

public class Wave
{
    public List<Enemy> enemiesInWave;
    public int enemyCount;
    public float spawnRate;
    public bool isWaveSpecial;
    public Dictionary<EnemyType, Transform> spawnPoints;
}
