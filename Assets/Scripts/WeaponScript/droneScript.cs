// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class droneScript : WeaponBase
// {   
//     [SerializeField] private float rotationSpeed;
//     [SerializeField] private GameObject bulletPrefab;
//     private WeaponManager weaponManager;
    

//     private void Start() 
//     {
//         weaponManager = FindObjectOfType<WeaponManager>();   
//     }

//     private void Update()
//     {
//         DroneRotation();
//         Attack();
//     }
//     public override void UpgradeWeapon()
//     {
//         if(level < maxLevel)
//         {
//             level++;
//             weaponData.weaponStats.damage *= 1.5f;
//             weaponManager.AddWeapon(weaponData);
//         }
//     }
//     public override void Attack()
//     {
//         weaponData.weaponStats.timeAttack -= Time.deltaTime;
//         if (weaponData.weaponStats.timeAttack<= 0)
//         {   
//             Instantiate(bulletPrefab, transform.position, transform.rotation);
//             weaponData.weaponStats.timeAttack = timeToAttack;
//         }
//     }
//     private void DroneRotation()
//     {
//         transform.RotateAround(weaponManager.weaponHolder.position,new Vector3(0f,0f,1f),rotationSpeed * Time.deltaTime );
//     }
// }
