using System;
using UnityEngine;
using Utils;

namespace DefaultNamespace.Behaviours
{
    public class EntityUIElement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        
        private Transform camera;

        private void Start()
        {
            camera = GameObject.FindWithTag(Tags.MainCamera).transform;
        }

        private void Update()
        {
            transform.rotation = camera.rotation;
            transform.position = target.position + offset;
        }   
    }
}