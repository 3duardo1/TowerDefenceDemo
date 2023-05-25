using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawnTimer : MonoBehaviour
{
    private GameObject attackerPrefab;
    private float spawnRate;

    private float meanSpawnDelay;

    private IEnumerator coroutine;

    public delegate void TimeToSpawn(GameObject attackerPrefab);
    public event TimeToSpawn OnTimeToSpawn;

    public AttackerSpawnTimer(GameObject attackerPrefab, float spawnRate){
        this.attackerPrefab = attackerPrefab;
        this.spawnRate = spawnRate;
    }

    public void StartTimer(GameObject attackerPrefab, float spawnRate){
        this.attackerPrefab = attackerPrefab;
        this.spawnRate = spawnRate;
    }

    void Update(){
        if (IsTimeToSpawn()){
            OnTimeToSpawn(attackerPrefab);
        }
    }

    bool IsTimeToSpawn(){
        meanSpawnDelay = spawnRate;
        float spawnsPerSecond = 1/meanSpawnDelay;
        float threshold = spawnsPerSecond * Time.deltaTime / 5;
        return Random.value < threshold;
    }
}
