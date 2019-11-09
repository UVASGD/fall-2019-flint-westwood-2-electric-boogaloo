using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public void SpawnNewEnemy(GameObject enemyToSpawn, Transform spawner)
    {
        Instantiate(enemyToSpawn, spawner.position, Quaternion.identity);
    }
}
