using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce;

    [SerializeField] private float rainShootCD;
    [SerializeField] private int bulletPrefabpool;
    void Update()
    {   
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    
    private void Attack()
    {
        Instantiate(bulletPrefab,shootPoint.position,shootPoint.rotation);   
    }



}
