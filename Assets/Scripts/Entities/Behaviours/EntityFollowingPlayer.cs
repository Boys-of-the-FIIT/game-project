using System;
using System.Collections;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class EntityFollowingPlayer : MonoBehaviour
    {
        [SerializeField] private Entity follower;
        [SerializeField] private float maxBetweenDistance;

        private PlayerEntity player;
        
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }
        
        private void FixedUpdate()
        {
            if (!player) return;
            
            var currentDistance = Vector2.Distance(transform.position, player.transform.position);

            if (currentDistance < maxBetweenDistance) return;
            
            var direction = player.transform.position - transform.position;
            var newPosition = transform.position + Time.deltaTime * follower.Stats.Speed * direction.normalized;
            transform.position = newPosition;
        }
    }
}