using System;
using System.Collections;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using Zenject;

namespace DefaultNamespace
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Transform player;

        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player).transform;
        }

        private void FixedUpdate()
        {
            if (!player.IsDestroyed())
            {
                var playerPosition = player.position;
                var transformPosition = transform.position;
                var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
                transform.position = Vector3.MoveTowards(transformPosition, target, Time.deltaTime * speed);
            }
        }
    }
}