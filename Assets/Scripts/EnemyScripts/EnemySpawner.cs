using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawner;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float decreaseTimeSpawn;
    [SerializeField] private float minimunSpawn;
    [SerializeField] private float spawn;
    private Transform player;
    private Coroutine spawnCoroutine;
    private bool canSpawn = true;
    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnCoroutine = StartCoroutine(Enemyspawner());
        
    }
    void Update()
    {   
        if(player == null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    public IEnumerator Enemyspawner()
    { 
        spawn = timeSpawn;
        while (canSpawn)
        {   
            //Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)],spawner[Random.Range(0,spawner.Length)].position,Quaternion.identity);
            GameObject enemy = EnemyPool.EnemyInstance.NeedEnemys();
            enemy.transform.position = spawner[Random.Range(0,spawner.Length)].position;
            spawn = Mathf.Max(minimunSpawn,spawn-decreaseTimeSpawn*Time.deltaTime);
            yield return new WaitForSeconds(spawn);
        }

    }
    public void Spawning()
    {
        canSpawn = false;
    }
}

