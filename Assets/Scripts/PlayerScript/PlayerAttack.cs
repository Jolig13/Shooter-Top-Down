using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Ataque")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.timeScale != 0)
        {
            Attack();
        }
    }
    private void Attack()
    {
        Instantiate(bulletPrefab,shootPoint.position,shootPoint.rotation);  

        AudioManager.AudioInstance.LaserPlayer(); 

        // GameObject bullet = BulletPool.playerBulletInstance.NeedBullet();
        // //bullet.transform.position = shootPoint.position;

        // Vector3 MouseAim = virtualCamera.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 AimDirection = MouseAim - shootPoint.position;
        // bullet.transform.rotation = Quaternion.LookRotation(AimDirection);
    }
}
