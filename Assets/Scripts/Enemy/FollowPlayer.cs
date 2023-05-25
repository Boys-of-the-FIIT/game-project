using System;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class FollowPlayer : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindWithTag(Tags.Player);
        }

        private void FixedUpdate()
        {
            var playerPosition = _player.transform.position;
            var transformPosition = transform.position;
            var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
            transform.position = Vector3.MoveTowards(transformPosition, target, Time.deltaTime);
        }
    }
}