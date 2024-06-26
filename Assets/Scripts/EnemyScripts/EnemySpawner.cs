using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeSpawn;
    void Start()
    {
        StartCoroutine(Enemyspawner());
    }

    IEnumerator Enemyspawner()
     { 
        while (true)
        {
            Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(timeSpawn);
        }
     }
}
