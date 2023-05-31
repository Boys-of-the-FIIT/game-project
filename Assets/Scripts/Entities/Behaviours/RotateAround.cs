using System;
using Player;
using UnityEngine;

namespace Behaviours
{
    public class RotateAround : MonoBehaviour
    {
        [SerializeField] private float speed;

        private PlayerEntity player;

        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }
        
        private void FixedUpdate()
        {
            transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
        }
    }
}