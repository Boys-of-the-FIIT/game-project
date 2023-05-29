using System;
using System.Collections.Generic;
using Bullets;
using UnityEngine;
using Utils;

namespace Shield
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private List<BulletType> bulletTypesResist;

        private void OnTriggerEnter2D(Collider2D col)
        { 
            if (!col.gameObject.CompareTag(Tags.Bullet)) return;
            if (!col.gameObject.TryGetComponent<Bullet>(out var bullet)) return;
            if (!bulletTypesResist.Contains(bullet.Type)) return;
            Destroy(col.gameObject);
        }
    }
}