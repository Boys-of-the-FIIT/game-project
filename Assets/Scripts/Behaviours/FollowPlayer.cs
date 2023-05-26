using System;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private float speed;
        private GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player);
        }

        private void FixedUpdate()
        {
            if (!player.IsDestroyed())
            {
                var playerPosition = player.transform.position;
                var transformPosition = transform.position;
                var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
                transform.position = Vector3.MoveTowards(transformPosition, target, Time.deltaTime * speed);
            }
        }
    }
}