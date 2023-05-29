using System.Collections.Generic;
using Bullets;
using UnityEngine;
using Utils;

namespace Shield
{
    public class ReverseBulletShield : MonoBehaviour
    {
        [SerializeField] private List<BulletType> bulletTypesResist;

        private void OnTriggerEnter2D(Collider2D col)
        { 
            if (!col.gameObject.CompareTag(Tags.Bullet)) return;
            if (!col.gameObject.TryGetComponent<Bullet>(out var bullet)) return;
            if (!bulletTypesResist.Contains(bullet.Type)) return;
            if (!bullet.TryGetComponent<Rigidbody2D>(out var bulletRb)) return;
            bulletRb.velocity = -bulletRb.velocity;
            bullet.Type = BulletType.EnemyBullet;
        }
    }
}