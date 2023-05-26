using UnityEngine;
using Utils;

namespace Behaviours
{
    public class IdleIfClose : MonoBehaviour
    {
        [SerializeField] private float distanceBetweenObjects;
        [SerializeField] private float speed;
        
        private Transform player;
        
        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player).transform;
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