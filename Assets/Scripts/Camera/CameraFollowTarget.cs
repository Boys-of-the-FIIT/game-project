using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Camera
{
    public class CameraFollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed;    
        
        private void FixedUpdate()
        {
            var playerPosition = player.transform.position;
            var transformPosition = transform.position;
            var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
            transform.position =
                Vector3.MoveTowards(transformPosition, target, Time.deltaTime * speed);
        }
    }
}