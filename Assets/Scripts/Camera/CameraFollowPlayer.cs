using Player;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Camera
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        [Inject] private PlayerEntity player;

        private void FixedUpdate()
        {
            var playerPosition = player.transform.position;
            var transformPosition = transform.position;
            var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
            transform.position =
                Vector3.MoveTowards(transformPosition, target, Time.deltaTime * 1000);
        }
    }
}