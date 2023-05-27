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
        
        private Camera camera;

        [Inject]
        private void Construct(Camera camera)
        {
            this.camera = camera;
        }
        
        private void Update()
        {
            transform.rotation = camera.transform.rotation;
            transform.position = target.position + offset;
        }   
    }
}