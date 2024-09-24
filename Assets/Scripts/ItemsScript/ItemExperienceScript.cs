// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ItemExperienceScript : MonoBehaviour
// {    
//     //[SerializeField] private Transform target;
//     private playerController player;
//     //[SerializeField] private float atractionDistance;
//     [SerializeField] private float speed;
//     [SerializeField] private int expAmount = 10;
//     // private bool isMovingToPlayer;
//     // [SerializeField] private float checkTime = 0.15f;
//     // private float counterCheck; 

//     private void Start()
//     {
//         //target = GameObject.FindGameObjectWithTag("Player").transform;
//         player = FindObjectOfType<playerController>();
//     }

//     private void Update() 
//     {
//         if(player != null)
//         {
//             FollowPlayer();
//         }  
//     }

//     private void FollowPlayer()
//     {
//         float playerDistance = Vector2.Distance(transform.position, player.transform.position);   

//         if(playerDistance < player.atractionDistance)
//         {
//             transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed* Time.deltaTime);
//         }
//         // if (isMovingToPlayer)
//         // {
//         //     transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
//         // }
//         // else
//         // {
//         //     counterCheck -= Time.deltaTime;
//         //     if (counterCheck <= 0)
//         //     {
//         //         counterCheck = checkTime;
//         //         if (playerDistance < target.atractionDistance)
//         //         {
//         //             isMovingToPlayer = true;
//         //         }
//         //     }
//         // }
//     }
//     private void OnTriggerEnter2D(Collider2D other) 
//     {   
//         PlayerController player = other.GetComponent<PlayerController>();
//         if(other.gameObject.CompareTag("Player"))
//         {   
//             //Debug.Log("Colision detectada");
//             player.ObtainExperience(expAmount);
//             Destroy(this.gameObject);    
//         }   
//     }
// }
