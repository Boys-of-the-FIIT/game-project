using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace DefaultNamespace.Camera
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        private PlayerController player;

        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player).GetComponent<PlayerController>();
        }

        private void FixedUpdate()
        {
            if (!player.IsDestroyed())
            {
                var playerPosition = player.transform.position;
                var transformPosition = transform.position;
                var target = new Vector3(playerPosition.x, playerPosition.y, transformPosition.z);
                transform.position =
                    Vector3.MoveTowards(transformPosition, target, Time.deltaTime * 1000);
            }
        }
    }
}