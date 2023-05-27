using Player;
using UnityEngine;
using Utils;
using Zenject;

namespace Behaviours
{
    public class IdleIfClose : MonoBehaviour
    {
        [SerializeField] private float distanceBetweenObjects;
        [SerializeField] private float speed;
        
        private Transform player;
        
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }

        private void Update()
        {
            var currentDistance = Vector3.Distance(transform.position, player.position);
            var direction = player.position - transform.position;
            var newPosition = transform.position + Time.deltaTime * speed * direction.normalized;
            transform.position = newPosition;
        }
    }
}