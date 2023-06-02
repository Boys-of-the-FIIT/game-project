using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private float dodgingRadius = 8;
        private Transform player;
        private float angleToKeep;
        private float distanceToKeep;
        private float distanceToPlayer;

        private float maxDodgingTime = 1.0f;
        private float dodgingTime;
        private bool isDodging;
        private Rigidbody2D dodgedBullet;
        private Vector3 bulletVelocity;
        private Vector3 bulletVelocityOrthogonal;
        private Vector3 playerToEnemy;

        private Vector3 playerShootingPosition;

        private HashSet<Collider2D> dodgedBullets = new();

        private Vector3 prevPosition;
        private Vector3 velocity;
        private float direction;

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
            UpdateVelocity();

            if (isDodging && dodgedBullet is not null)
            {
                DodgeBullet();
                return;
            }

            var colliders = Physics2D.OverlapCircleAll(transform.position, dodgingRadius);
            var bullet = colliders.FirstOrDefault(coll => coll.CompareTag("Bullet"));

            if (!isDodging && bullet is { name: "Player Bullet" or "Player Bullet(Clone)" }
                           && dodgedBullets.Add(bullet))
            {
                UpdateDodgingData(bullet);
                DodgeBullet();
                return;
            }

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

        private void UpdateDodgingData(Collider2D bullet)
        {
            isDodging = true;
            if (!bullet.TryGetComponent<Rigidbody2D>(out dodgedBullet))
            {
                return;
            }

            bulletVelocity = dodgedBullet.velocity;
            bulletVelocityOrthogonal = Vector3.Cross(bulletVelocity, Vector3.forward);
            playerShootingPosition = player.position;

            playerToEnemy = transform.position - playerShootingPosition;

            var playerToEnemyOrthogonal = Vector3.Cross(playerToEnemy, Vector3.forward);
            var orthogonalDotBulletVelocity = Vector3.Dot(playerToEnemyOrthogonal, bulletVelocity);
            var orthogonalDotEnemy = Vector3.Dot(playerToEnemyOrthogonal, velocity);

            var sign = -orthogonalDotBulletVelocity * orthogonalDotEnemy;

            direction = Mathf.Sign(sign);
        }

        private void UpdateVelocity()
        {
            velocity = (transform.position - prevPosition) / Time.deltaTime;
            prevPosition = transform.position;
        }

        private void DodgeBullet()
        {
            dodgingTime += Time.deltaTime;

            if (dodgingTime > maxDodgingTime)
            {
                StopDodging();
                return;
            }

            if (!dodgedBullet) return;
            
            var enemyPosition2d = new Vector2(transform.position.x, transform.position.y);
            var enemyToBullet = dodgedBullet.position - enemyPosition2d;

            var dot = Vector3.Dot(enemyToBullet, bulletVelocity);

            if (dot > 0)
            {
                StopDodging();
                return;
            }

            transform.position += direction * bulletVelocityOrthogonal.GetDirectionWithSpeed(speed);
        }

        private void StopDodging()
        {
            isDodging = false;
            dodgingTime = 0;
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