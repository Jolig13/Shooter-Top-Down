using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawnerManager : MonoBehaviour
{   
    [SerializeField] private float maxDropX;
    [SerializeField] private float minDropX;
    [SerializeField] private float maxDropY;
    [SerializeField] private float minDropY;
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private float minSpawm;
    [SerializeField] private float maxSpawn;
    private bool canSpawn = true;
    private GameObject player;
    
    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnChest());   
    }

    void Update()
    {
        if(player == null)
        {
           StopChestSpawning();
        }   
    }
    private IEnumerator SpawnChest()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(Random.Range(maxSpawn,minSpawm));
            AppearedChest();
        }
    }
    private void AppearedChest()
    {
        var xPosition = Random.Range(maxDropX,minDropX);
        var yPosition = Random.Range(maxDropY,minDropY);
        var chestPosition = new Vector2 (xPosition,yPosition);
        Instantiate(chestPrefab, chestPosition,Quaternion.identity);
        Debug.Log("Cofre Instanciado");
    }
    public void StopChestSpawning()
    {
        canSpawn = false;
    }
}
