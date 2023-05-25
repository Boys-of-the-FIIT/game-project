using System;
using UnityEngine;

namespace MainCamera
{
    public class MainCameraBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform player;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                 Time.deltaTime);
        }
    }
}