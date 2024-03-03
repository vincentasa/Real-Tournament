using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnPoints;
    public List<int> enemiesPerWave;

    
    [Range(0.1f,10f)]
    public float spawnInterval = 1f;

    public int enemiestoSpawn;

    void Spawn()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, point.position, point.rotation);
    }

    async void Start()
    {
        foreach (var num in enemiesPerWave)
        {
            enemiestoSpawn = num;
        }
        
        
        enemiestoSpawn = enemiesPerWave[0];
        while (enemiestoSpawn > 0)
        {
            await new WaitForSeconds(spawnInterval); 
            Spawn();
            enemiestoSpawn--;
        }
    }
}
