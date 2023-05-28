using System;
using System.Collections;
using Player;
using UnityEngine;
using Utils;

namespace DefaultNamespace.Abilities
{
    public class ShockWave : Ability
    {
        [SerializeField] private float damage;
        public override void Invoke()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(var collider in colliders)
            {
                if (collider.gameObject.CompareTag(Tags.Enemy))
                    collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}