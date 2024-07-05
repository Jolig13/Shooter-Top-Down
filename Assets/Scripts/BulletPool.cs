// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BulletPool : MonoBehaviour
// {   
//     public static BulletPool playerBulletInstance {get; private set;}  
//     [SerializeField] private GameObject bulletPrefab;
//     [SerializeField] private int bulletAmount;
//     [SerializeField] private List<GameObject> bullets;

//     private void Awake() 
//     {
//         if (playerBulletInstance == null)
//         {
//             playerBulletInstance = this;
//         }   
//         else
//         {
//             Destroy(this.gameObject);
//         }
//     }
//     private void Start() 
//     {
//         BulletForPool(bulletAmount);
//     }

//     private void BulletForPool(int amount)
//     {
//         for (int i = 0; i < amount; i++)
//         {
//             GameObject bullet = Instantiate(bulletPrefab);
//             bullet.SetActive(false);
//             bullets.Add(bullet);
//             bullet.transform.parent = transform ;
            
//         }
//     }

//     public GameObject NeedBullet()
//     {
//         for (int i = 0; i < bullets.Count; i++)
//         {
//             if (!bullets[i].activeSelf)
//             {
//                 bullets[i].SetActive(true);
//                 return bullets[i];
//             }
//         }
//         BulletForPool(1);
//         bullets[bullets.Count-1].SetActive(true);
//         return bullets[bullets.Count-1];
//     }
// }
