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
            var directionVector = _player.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Time.deltaTime);
        }
    }
}