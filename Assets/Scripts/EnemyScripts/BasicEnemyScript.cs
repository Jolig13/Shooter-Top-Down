using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{   
    private Transform target;
    private Rigidbody2D rb2D;
    [SerializeField] private float speedMove;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject proyectilePrefab;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireCD;
    [SerializeField] private float rangeAttack;
    [SerializeField] private float distancePlayer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        fireCD = fireRate;
    }

    private void Update() 
    {
        distancePlayer = Vector2.Distance(transform.position, target.position);

        if(target != null && distancePlayer >= rangeAttack)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if(target != null)
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
            Instantiate(proyectilePrefab,shootPoint.position,shootPoint.rotation);  
            fireCD = fireRate;
        }
        else
        {
            fireCD -= Time.deltaTime;
        }
    }
     
}
