using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float reloadTime;
        private PlayerEntity playerEntity;
        private bool canShoot = true;
        
        private void Start()
        {
            playerEntity = GameObject.FindWithTag(Tags.Player).GetComponent<PlayerEntity>();
            bulletPrefab.GetComponent<Bullet>().Type = BulletType.EnemyBullet;
        }

        private void Update()
        {
            if (!playerEntity.IsDestroyed())
            {
                if (Vector3.Distance(gameObject.transform.position, playerEntity.transform.position) < attackRange)
                {
                    if (canShoot) StartCoroutine(Shoot());
                }
            }
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