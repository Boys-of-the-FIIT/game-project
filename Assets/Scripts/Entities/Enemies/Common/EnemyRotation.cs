using System;
using DefaultNamespace;
using Player;
using UnityEngine;
using Utils;
using Zenject;

namespace Enemies
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
            var predictPosition = VectorExtensions.CalculateInterception(
                transform.position,
                player.position,
                enemy.Stats.BulletSpeed,
                CalculatePlayerVelocity()
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
    }
}