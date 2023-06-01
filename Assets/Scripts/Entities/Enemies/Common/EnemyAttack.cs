using System.Collections;
using Bullets;
using Player;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Enemy enemy;

        private bool canShoot = true;
        private PlayerEntity player;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }

        private void Start()
        {
            enemy = GetComponentInParent<Enemy>();
        }

        private void Update()
        {
            if (!player) return;
            var distanceToPlayer = Vector3.Distance(enemy.transform.position, player.transform.position);
            if (distanceToPlayer < enemy.Stats.AttackDistance)
            {
                if (canShoot) StartCoroutine(Shoot());
            }
        }

        private IEnumerator Shoot()
        {
            var resultRotation = transform.rotation * Quaternion.Euler(0, 0, 90);

            var bullet = Instantiate(bulletPrefab, transform.position, resultRotation).GetComponent<Bullet>()
                .Construct(
                    BulletType.EnemyBullet,
                    enemy.Stats.Damage,
                    enemy.Stats.AttackDistance,
                    enemy.Stats.BulletSpeed
                );

            canShoot = false;
            yield return new WaitForSeconds(enemy.Stats.ReloadTime);
            canShoot = true;
        }
    }
}