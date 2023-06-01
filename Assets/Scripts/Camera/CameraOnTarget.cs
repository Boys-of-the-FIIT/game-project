using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Camera
{
    public class CameraOnTarget : MonoBehaviour
    {
        [SerializeField] private Transform player;
        // [SerializeField] private float speed;    
        
        private void FixedUpdate()
        {
            // var playerPosition = player.transform.position;
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            // var transformPosition = transform.position;
            // var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
            // Vector3.MoveTowards(transformPosition, target, Time.deltaTime * speed);
        }
    }
}