using System.Collections;
using Bullet;
using UnityEngine;

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
            var currentTransform = transform;
            Instantiate(
                bulletPrefab,
                currentTransform.position, 
                currentTransform.rotation * Quaternion.Euler(0, 0, 90)
            );

            canShoot = false;
            yield return new WaitForSeconds(reloadTime);
            canShoot = true;
        }
    }
}