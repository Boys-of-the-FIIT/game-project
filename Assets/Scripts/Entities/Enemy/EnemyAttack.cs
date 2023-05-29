using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using Player;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using Zenject;

namespace DefaultNamespace
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float reloadTime;
        

        private bool canShoot = true;
        private Enemy enemy;
        private Transform player;
        
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }
        
        private void Start()
        {
            enemy = GetComponentInParent<Enemy>();
            bulletPrefab.GetComponent<Bullet>().Type = BulletType.EnemyBullet;
        }

        private void Update()
        {
            if (!player) return;
            if (Vector3.Distance(enemy.transform.position, player.position) < attackRange)
            {
                if (canShoot) StartCoroutine(Shoot());
            }
        }
        
        private IEnumerator Shoot()
        {
            var resultRotation = transform.rotation * Quaternion.Euler(0, 0, 90);
            Instantiate(bulletPrefab, transform.position, resultRotation);
            canShoot = false;
            yield return new WaitForSeconds(reloadTime);
            canShoot = true;
        }
    }
}