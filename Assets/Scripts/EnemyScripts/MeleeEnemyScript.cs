using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour
{   
    private Rigidbody2D rb2D;
    private Transform target;
    [SerializeField] private float speedMove;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            PlayerController playerInstance = other.gameObject.GetComponent<PlayerController>();
            {
                GameManager.Instance.DamageReceive();
            }
            Destroy(this.gameObject);
        }   
    }
}   