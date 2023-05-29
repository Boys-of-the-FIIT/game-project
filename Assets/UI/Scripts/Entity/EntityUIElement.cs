using System;
using UnityEngine;
using Utils;
using Zenject;

namespace Behaviours
{
    public class EntityUIElement : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Camera mainCamera;
        private Vector3 initialPosition;
        
        [Inject] 
        private void Construct(Camera mainCamera)
        {
            this.mainCamera = mainCamera;
        }

        private void Start()
        {
            initialPosition = transform.position - target.position;
        }

        private void Update()
        {
            transform.rotation = mainCamera.transform.rotation;
            transform.position = target.position + initialPosition;
        }   
    }
}