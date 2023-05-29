using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Bullets;
using Zenject;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;

        private bool canShoot;
        private System.Random random;
        private PlayerEntity player;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }

        private void Awake()
        {
            canShoot = true;
        }

        private void Start()
        {
            random = new System.Random();
        }

        private void Update()
        {
            if (canShoot && Input.GetKey(KeyCode.Mouse0))
                StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            var randomAngle = player.Stats.RecoilAngle * ((float)random.NextDouble() - 0.5f);
            var resultRotation = transform.rotation * Quaternion.Euler(0, 0, 90 + randomAngle);

            var bullet = Instantiate(
                bulletPrefab,
                transform.position,
                resultRotation
            ).Construct(
                BulletType.PlayerBullet,
                player.Stats.Damage,
                player.Stats.AttackDistance,
                player.Stats.BulletSpeed
            );
            
            var recoilVector = -0.1f * bullet.transform.right;
            canShoot = false;
            yield return new WaitForSeconds(player.Stats.ReloadTime);
            canShoot = true;
        }
    }
}