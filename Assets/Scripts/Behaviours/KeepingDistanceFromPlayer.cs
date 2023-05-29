using System;
using Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using Utils;

namespace Behaviours
{
    public class KeepingDistanceFromPlayer : MonoBehaviour
    {
        [SerializeField] private float minDistanceToPlayer = 5;
        [SerializeField] private float maxDistanceToPlayer = 10;
        [SerializeField] private float speed;
        
        private Transform player;
        private float angleToKeep;
        private float distanceToKeep;
        private float distanceToPlayer;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }
        
        private void Start()
        {
            angleToKeep = Random.Range(-180f, 180f);
            distanceToKeep =
                Random.Range(minDistanceToPlayer, maxDistanceToPlayer);
        }

        private void Update()
        {
            if (!player) return;
            distanceToPlayer = Vector3.Distance(transform.position, player.position);

            var directionTowardsPlayer = player.position - transform.position;

            if (distanceToPlayer < minDistanceToPlayer)
            {
                RunFromPlayer(directionTowardsPlayer);
                return;
            }

            if (minDistanceToPlayer < distanceToPlayer && distanceToPlayer <= maxDistanceToPlayer)
            {
                KeepDistanceToPlayer(directionTowardsPlayer);
                return;
            }

            if (distanceToPlayer <= maxDistanceToPlayer) return;

            ChasePlayer(directionTowardsPlayer);
        }

        private void ChasePlayer(Vector3 directionTowardsPlayer)
        {
            var newPosition = transform.position + directionTowardsPlayer.GetDirectionWithSpeed(speed);
            var newDistance = Vector3.Distance(player.position, newPosition);

            if (newDistance > minDistanceToPlayer)
            {
                transform.position = newPosition;
            }
        }

        private void KeepDistanceToPlayer(Vector3 directionTowardsPlayer)
        {
            var currentAngle = Vector3.SignedAngle(
                Vector3.right,
                transform.position - player.position,
                Vector3.forward
            );

            var angleDifference = currentAngle - angleToKeep;

            if (angleDifference is > 10 or < -10)
            {
                GoAroundPlayer();
                return;
            }

            var distancesDifference = distanceToPlayer - distanceToKeep;

            if (Math.Abs(distancesDifference) <= 1.0) return;

            GoToDistanceToKeep(distancesDifference, directionTowardsPlayer);
        }

        private void GoToDistanceToKeep(float distancesDifference, Vector3 directionTowardsPlayer)
        {
            var sign = Math.Sign(distancesDifference);
            var playerDirection = sign * directionTowardsPlayer.GetDirectionWithSpeed(speed);
            var newPositionToPlayerDistance = Vector3.Distance(transform.position + playerDirection, player.position);

            if (newPositionToPlayerDistance < minDistanceToPlayer
                || Math.Abs(newPositionToPlayerDistance - distanceToKeep) <= 1.0
                || Math.Abs(distancesDifference) <= 1.0)
            {
                return;
            }

            transform.position += playerDirection;
        }

        private void GoAroundPlayer()
        {
            var playerToEnemy = transform.position - player.position;
            var orthogonal = Vector3.Cross(playerToEnemy, Vector3.forward);

            transform.position += orthogonal.GetDirectionWithSpeed(speed);
        }

        private void RunFromPlayer(Vector3 directionTowardsPlayer)
        {
            transform.position -= directionTowardsPlayer.GetDirectionWithSpeed(speed);
        }
    }
}