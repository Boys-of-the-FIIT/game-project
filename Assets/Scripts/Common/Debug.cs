using System;
using UnityEngine;
using Zenject;

namespace Common
{
    public class Debug : MonoBehaviour
    {
        private Camera camera;

        [Inject]
        private void Construct(Camera camera)
        {
            this.camera = camera;
        }

        private Vector3 CameraPos => camera.transform.position;
        
        private void Update()
        {

        }
    }
}