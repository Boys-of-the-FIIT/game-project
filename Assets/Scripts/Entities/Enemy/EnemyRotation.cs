using System;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Player
{
    public class EnemyRotation : MonoBehaviour
    {
        [Range(0, 1)] [SerializeField] private float speed = 1f;
        [SerializeField] private Enemy enemy;
        private Transform player;

        private Vector3 prevPosition;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }

        private void FixedUpdate()
        {
            var playerVelocity = CalculatePlayerVelocity();

            var predictPosition = CalculateInterception(
                transform.position,
                player.position,
                enemy.Stats.BulletSpeed,
                playerVelocity
            );

            var x = predictPosition.x;
            var y = predictPosition.y;
            var predictPosition3d = new Vector3(x, y, 0);

            var rotation = predictPosition3d - transform.position;
            var rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ * speed);

            prevPosition = player.position;
        }

        private Vector3 CalculatePlayerVelocity()
        {
            return (transform.position - prevPosition) / Time.deltaTime;
        }

        private Vector3 CalculateInterception(
            Vector3 shooterLocation, // Pc
            Vector3 targetLocation, // Pr
            float bulletSpeed, // Sc
            Vector3 targetVelocity // Vr
        )
        {
            var targetSpeed = targetVelocity.magnitude; // Sr

            var targetToShooterDirection = shooterLocation - targetLocation; // D
            var shooterToTargetDistance = targetToShooterDirection.magnitude; // d

            var a = bulletSpeed * bulletSpeed - targetSpeed * targetSpeed;
            var b = 2 * Vector3.Dot(targetToShooterDirection, targetVelocity);
            var c = -shooterToTargetDistance * shooterToTargetDistance;

            var b2 = b * b;
            var ac4 = 4 * a * c;
            var a2 = 2 * a;

            var t1 = (-b + Mathf.Sqrt(b2 - ac4)) / a2;
            var t2 = (-b - Mathf.Sqrt(b2 - ac4)) / a2;

            if (t1 < 0 && t2 < 0)
            {
                return targetLocation;
            }

            var t = t1 > 0 && t2 > 0
                ? Mathf.Min(t1, t2)
                : Mathf.Max(t1, t2);

            var pointIntersection = targetLocation + t * targetVelocity;

            return pointIntersection;
        }
    }
}