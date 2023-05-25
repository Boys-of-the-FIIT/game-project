using System;
using Player;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange;
        [SerializeField] private GameObject bulletPrefab;
        private PlayerEntity playerEntity;
        private void Start()
        {
            playerEntity = GameObject.FindWithTag(Tags.Player).GetComponent<PlayerEntity>();
        }

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