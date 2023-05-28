using System;
using Player;
using UnityEngine;
using Zenject;

namespace Behaviours
{
    public class KeepingDistanceFromPlayer : MonoBehaviour
    {
        [SerializeField] private float distanceBetweenObjects;
        [SerializeField] private float speed;
        
        [Inject]private PlayerEntity player;


        private void Update()
        {
            var currentDistance = Vector3.Distance(transform.position, player.transform.position);
            var direction = player.transform.position - transform.position;
            if(currentDistance <= distanceBetweenObjects) 
                direction = -1 * direction; 
            var newPosition = transform.position + Time.deltaTime * speed * direction.normalized;
            transform.position = newPosition;
        }
    }
}