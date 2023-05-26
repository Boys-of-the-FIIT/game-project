using System;
using UnityEngine;

namespace DefaultNamespace.Behaviours
{
    public class FreezeRotation : MonoBehaviour
    {
        private Quaternion rotation;
        private Vector3 startLocalPos;
        private void Awake()
        {
            rotation = transform.rotation;
            startLocalPos = transform.localPosition;
        }

        private void FixedUpdate()
        {
            transform.rotation = rotation;
            transform.localPosition = startLocalPos;
        }
    }
}