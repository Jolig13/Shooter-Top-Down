using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExperienceScript : MonoBehaviour
{    
    private Transform target;
    [SerializeField] private float atractionDistance;
    [SerializeField] private float speed;
    [SerializeField] private int expAmount = 10;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() 
    {
        if(target != null)
        {
            FollowPlayer();
        }  
    }

    private void FollowPlayer()
    {
        float playerDistance = Vector2.Distance(transform.position, target.position);   

        if(playerDistance < atractionDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed* Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {   
        PlayerController player = other.GetComponent<PlayerController>();
        if(other.gameObject.CompareTag("Player"))
        {   
            //Debug.Log("Colision detectada");
            player.ObtainExperience(expAmount);
            Destroy(this.gameObject);    
        }   
    }
}
