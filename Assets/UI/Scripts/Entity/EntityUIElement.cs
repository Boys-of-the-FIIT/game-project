using System;
using UnityEngine;
using Utils;
using Zenject;

namespace Behaviours
{
    public class EntityUIElement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        // [SerializeField] private Vector3 offset;
        
        private Camera mainCamera;
        
        [Inject] 
        private void Construct(Camera mainCamera)
        {
            this.mainCamera = mainCamera;
        }
        
        private void Update()
        {
            transform.rotation = mainCamera.transform.rotation;
            transform.position = target.position;
        }   
    }
}