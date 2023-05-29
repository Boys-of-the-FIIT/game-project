using System;
using System.Collections;
using Player;
using UnityEngine;
using Zenject;

namespace Entities.Enemy
{
    public class KamikazeEnemy : DefaultNamespace.Enemy
    {
        [SerializeField] private float explosionDelay;
        [SerializeField] private float explosionRange;
        
        private Transform player;
         
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }
        
        private void Update()
        {
            if (Vector2.Distance(player.position, transform.position) < 5)
            {
                StartCoroutine(Explosion());
                return;
            }
        }

        private void Explode()
        {
               
        }

        private IEnumerator Explosion()
        {
            yield return new WaitForSeconds(explosionDelay);
            
            Die();
        }
    }
}