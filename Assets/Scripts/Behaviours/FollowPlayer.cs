using System;
using System.Collections;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private float speed;
        [Inject] private PlayerEntity player;

        private void FixedUpdate()
        {
            var playerPosition = player.transform.position;
            var transformPosition = transform.position;
            var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
            transform.position = Vector3.MoveTowards(transformPosition, target, Time.deltaTime * speed);
        }
    }
}