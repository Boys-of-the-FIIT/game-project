using System;
using UnityEngine;

namespace Behaviours
{
    public class RotateAround : MonoBehaviour
    {
        [SerializeField] private float speed;
        private void FixedUpdate()
        {
            transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
        }
    }
}