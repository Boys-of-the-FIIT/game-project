using Player;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using Zenject;

namespace DefaultNamespace.Camera
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        private Transform player;
    
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }

        private void FixedUpdate()
        {

            var playerPosition = player.position;
            var transformPosition = transform.position;
            var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
            transform.position =
                Vector3.MoveTowards(transformPosition, target, Time.deltaTime * 1000);
        }
    }
}