using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{   
    public static EnemyPool EnemyInstance {get; private set;}  
    [SerializeField] private GameObject[] EnemyPrefab;
    [SerializeField] private int enemyPoolSize;
    [SerializeField] private List<GameObject> enemys;

    private void Awake() 
    {
        if (EnemyInstance == null)
        {
            EnemyInstance = this;
        }   
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start() 
    {
        EnemyForPool(enemyPoolSize);
    }

    private void EnemyForPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab[Random.Range(0,EnemyPrefab.Length)]);
            enemy.SetActive(false);
            enemys.Add(enemy);
            enemy.transform.parent = transform ;
            
        }
    }

    public GameObject NeedEnemys()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            if (!enemys[i].activeSelf)
            {
                enemys[i].SetActive(true);
                return enemys[i];
            }
        }
        EnemyForPool(1);
        enemys[enemys.Count-1].SetActive(true);
        return enemys[enemys.Count-1];
    }
}
