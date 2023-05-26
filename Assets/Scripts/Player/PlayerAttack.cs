using System;
using System.Collections;
using System.Collections.Generic;
using Bullet;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float reloadTime;
        private bool canShoot = true;

        private void Start()
        {
            bulletPrefab.GetComponent<Bullet.Bullet>().Type = BulletType.PlayerBullet;
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