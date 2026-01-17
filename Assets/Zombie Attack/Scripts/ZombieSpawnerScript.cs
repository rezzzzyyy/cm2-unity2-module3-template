using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform target;

    public float spawnRange = 10;

    public UnityEvent ZombieDied;

    void Start()
    {
        StartCoroutine(ZombieSpawnRepeater());
    }

    public IEnumerator ZombieSpawnRepeater()
    {
        yield return new WaitForSeconds(2f);
        SpawnZombie();
        
        StartCoroutine(ZombieSpawnRepeater());
        
    }
    
    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 1, Random.Range(-spawnRange, spawnRange));
    }

    public void SpawnZombie()
    {
        GameObject zombie = Instantiate(zombiePrefab);
        target.position = RandomPosition();
        zombie.GetComponent<ZombieScript>().Init(target, this);
    }

    public void ZombieHasDied()
    {
        ZombieDied?.Invoke();
    }

    // LESSON 3-4: Add coroutine below.
}
