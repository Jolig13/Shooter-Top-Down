using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{   
    private Transform target;
    private Rigidbody2D rb2D;
    [SerializeField] private float speedMove;
    [SerializeField] private Transform shootPoint;
    //[SerializeField] private GameObject proyectilePrefab;
    //[SerializeField] private BulletPool bulletPool;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireCD;
    [SerializeField] private float rangeAttack;
    [SerializeField] private float playerRange;
    private float playerDistance;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        fireCD = fireRate;
    }

    private void Update() 
    {   
        if (target != null)
        {
            playerDistance = Vector2.Distance(transform.position, target.position);
        }

        if(target != null && playerDistance <= rangeAttack)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if(target != null && playerDistance >= playerRange)
        {
            Follow();
        }

    }

    private void Follow()
    {    
        Vector2 direction = (target.position-transform.position).normalized;
        rb2D.MovePosition(rb2D.position+direction*speedMove*Time.deltaTime);
        
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg-90f;
        rb2D.rotation = angle;
    }

    private void Shoot()

    {  
        if(fireCD <= 0f)
        {
            //Instantiate(proyectilePrefab,shootPoint.position,shootPoint.rotation);
                // GameObject bullet = bulletPool.NeedBullet();
                // bullet.transform.position = shootPoint.position;  
            fireCD = fireRate;
        }
        else
        {
            fireCD -= Time.deltaTime;
        }
    }
    
    // private void OnCollisionEnter2D(Collision2D other) 
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {   
    //         PlayerController playerInstance = other.gameObject.GetComponent<PlayerController>();
    //         {
    //             GameManager.Instance.DamageReceive();
    //         }
    //         Destroy(this.gameObject);
    //     }   
    // }
    // private void OnDrawGizmos()
    // {
    //         Gizmos.color = Color.yellow;
    //         Gizmos.DrawWireSphere(transform.position,playerRange);
    //         Gizmos.DrawWireSphere(transform.position,rangeAttack);
    // }
}
