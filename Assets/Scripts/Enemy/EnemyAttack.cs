using System;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange;
        [SerializeField] private Player.PlayerEntity playerEntity;
        [SerializeField] private GameObject bulletPrefab;

        private void Update()
        {
            if (Vector3.Distance(gameObject.transform.position, playerEntity.transform.position) < attackRange)
            {
                Attack();
            }
        }

        private void Attack()
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}