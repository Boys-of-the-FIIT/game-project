using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float reloadTime;
        private bool _canShoot = true;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && _canShoot)
            {
                StartCoroutine(Shoot());
            }
        }

        private IEnumerator Shoot()
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            _canShoot = false;
            yield return new WaitForSeconds(reloadTime);
            _canShoot = true;
        }
    }
}