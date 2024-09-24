using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour
{
    [SerializeField] private float lifeTime;


    private void Start() 
    {
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
   
            ShowChestItems();
        }   
    }
    private void Update() 
    {
        Destroy(this.gameObject,lifeTime);   
    }
    public void ShowChestItems()
    {
    }
 
}

