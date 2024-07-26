using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    //[SerializeField] private float timeActive;
    
    private void Awake() 
    {
        bulletRb = GetComponent<Rigidbody2D>();   
    }
    private void Start() 
    {
        bulletRb.velocity = transform.up * speed ;//* Time.deltaTime;
        //bulletRb.AddForce(transform.up * speed,ForceMode2D.Impulse);   
    }
    void Update()
    {   
        Destroy(this.gameObject,lifeTime);
        // timeActive += Time.deltaTime;
        // if (timeActive > lifeTime)
        // {
        //     gameObject.SetActive(false);
        //     timeActive = 0;
        // }
    }
    

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.gameObject.CompareTag("Enemy"))
    //     {   
    //         other.gameObject.SetActive(false);
    //         Destroy(this.gameObject);
    //         GameManager.Instance.Score();
    //         AudioManager.AudioInstance.EnemyDestroy();
    //         //gameObject.SetActive(false);
    //         //other.gameObject.SetActive(false);
    //     }    

    // }
}   
