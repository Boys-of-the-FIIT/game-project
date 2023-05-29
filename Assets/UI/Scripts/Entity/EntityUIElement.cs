using System;
using UnityEngine;
using Utils;
using Zenject;

namespace Behaviours
{
    public class EntityUIElement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [Inject] private Camera mainCamera;

        private void Update()
        {
            transform.rotation = mainCamera.transform.rotation;
            transform.position = target.position + offset;
        }   
    }
}