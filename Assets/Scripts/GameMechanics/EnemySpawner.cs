using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] attackers;
    private List<AttackerSpawnTimer> spawnTimers = new List<AttackerSpawnTimer>();

    private IEnumerator coroutine;

    void Start()
    {
        foreach (GameObject attacker in attackers){
            float attackerSpawnRate = attacker.GetComponent<BaseCombat>().spawnRate;
            AttackerSpawnTimer attackerSpawnTimer = gameObject.AddComponent<AttackerSpawnTimer>();
            attackerSpawnTimer.StartTimer(attacker, attackerSpawnRate);
            attackerSpawnTimer.OnTimeToSpawn += SpawnEnemy;
            spawnTimers.Add(attackerSpawnTimer);
        }
    }

    void SpawnEnemy(GameObject myGameObject){
        GameObject SpawnedAttacker = Instantiate (myGameObject) as GameObject;
		SpawnedAttacker.transform.parent = transform;
		SpawnedAttacker.transform.position = transform.position;
    }

    public void StopSpawning(){
        foreach (AttackerSpawnTimer timer in spawnTimers){
            Destroy(timer);
        }
    }
}
