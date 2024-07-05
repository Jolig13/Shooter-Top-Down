using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D enemyBulletRb;

    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float timeActive;

    private void Awake() 
    {
        enemyBulletRb = GetComponent<Rigidbody2D>();  
    }
    
    private void OnEnable() 
    {
        //enemyBulletRb.AddForce(transform.up * speed, ForceMode2D.Impulse);   
    }
    void Update()
    {   
        timeActive += Time.deltaTime;
        if (timeActive > lifeTime)
        {
            gameObject.SetActive(false);
            timeActive = 0;
        }
    }
    
    private void OnCollisionEnter2D (Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            PlayerController playerInstance = other.gameObject.GetComponent<PlayerController>();
            {
                GameManager.Instance.DamageReceive(); 
                gameObject.SetActive(false);
            }

           
        }   
    }
}
