using System;
using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public string waveDescription;
    private TextMeshProUGUI waveCountdownText;

    public float waveTimer;
    public int numEnemiesRemaining;
    private int startingWave = 0;
    public int currentWave;

    public List<Wave> waves;
    public SpawnManager spawnManager;



    void HandleWaveSpawning()
    {
        if (waves[currentWave].enemyCount <= 0)
        {
            EndWave();
        }

        if (currentWave >= waves.Count)
        {
            // either repeat (start random waves)
            // or broadcast a game over message
            HandleGameWin();
        }

        if (waves[currentWave].isWaveSpecial)
        {
            HandleSpecialWave();
        }
    }

    private void HandleGameWin()
    {
        throw new System.NotImplementedException();
    }

    private void EndWave()
    {
        throw new System.NotImplementedException();
    }

    private void HandleSpecialWave()
    {
        Debug.Log("This wave is special");
    }

    IEnumerator SpawnAllWaves()
    {
        for (currentWave = startingWave; currentWave < waves.Count; currentWave++)
        {
            yield return StartCoroutine(SpawnNewWave(waves[currentWave]));
        }
        yield return null;
    }

    IEnumerator SpawnNewWave(Wave wave)
    {
        for (int i = 0; i < wave.enemyCount; i++)
        {
            Enemy enemyToSpawn = wave.enemiesInWave[(int) Random.Range(0f, wave.enemiesInWave.Count - 1)];
            Transform enemySpawnPosition =
                wave.spawnPoints[enemyToSpawn.enemyAttributes.enemyType];
            spawnManager.SpawnNewEnemy(enemyToSpawn.gameObject, enemySpawnPosition);
            yield return new WaitForSeconds(1f / wave.spawnRate); // num enemies per second e.g 3 enemies = spawns new enemy every .33 sec
        }
    }
}
