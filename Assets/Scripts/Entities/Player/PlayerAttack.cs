using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Bullets;
using Utils;
using Zenject;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float reloadTime;
        [Range(0, 180)] [SerializeField] private float spreadAngle;
        
        private bool canShoot = true;
        private System.Random random;
        
        private void Start()
        {
            bulletPrefab.Type = BulletType.PlayerBullet;
            random = new System.Random();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && canShoot)
                StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            var randomAngle = spreadAngle * ((float)random.NextDouble() - 0.5f);
            var resultRotation = transform.rotation * Quaternion.Euler(0, 0, 90 + randomAngle);
            var bullet = Instantiate(
                bulletPrefab,
                transform.position,
                resultRotation
            );
            var recoilVector = -0.1f * bullet.transform.right;
            canShoot = false;
            yield return new WaitForSeconds(reloadTime);
            canShoot = true;
        }
    }
}