using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Bullets;
using Utils;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float reloadTime;
        private bool canShoot = true;
        
        private void Start()
        {
            bulletPrefab.Type = BulletType.PlayerBullet;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && canShoot)
                StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            canShoot = false;
            yield return new WaitForSeconds(reloadTime);
            canShoot = true;
        }
    }
}