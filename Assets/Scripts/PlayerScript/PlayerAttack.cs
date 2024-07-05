using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    
    [SerializeField] private Transform shootPoint;
    //[SerializeField] private GameObject bulletPrefab;



    void Update()
    {   
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    
    private void Attack()
    {
        // Instantiate(bulletPrefab,shootPoint.position,shootPoint.rotation);   

        //GameObject bullet = BulletPool.playerBulletInstance.NeedBullet();
        //bullet.transform.position = transform.position;
        //sbullet.transform.rotation = Quaternion.LookRotation;
    }

}
