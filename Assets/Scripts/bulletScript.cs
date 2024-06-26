using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Rigidbody2D bulletRb;

    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        bulletRb.velocity = transform.up * speed;
        Destroy(this.gameObject,lifeTime);
    }
}
