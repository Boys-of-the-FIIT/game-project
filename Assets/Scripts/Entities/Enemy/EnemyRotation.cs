using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Player
{
    public class EnemyRotation : MonoBehaviour
    {
        [Inject] private PlayerEntity player;

        private void FixedUpdate()
        {
            var rotation = player.transform.position - new Vector3(transform.position.x, transform.position.y, 0);
            var rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }
}