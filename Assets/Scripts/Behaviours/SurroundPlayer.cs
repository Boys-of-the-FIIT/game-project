using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

public class SurroundPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float beginSurroundDistance;
    [SerializeField] private float noSurroundDistance;
    [SerializeField] private float angularSpeed;
    
    private Transform player;
    private float angularDirection;

    [Inject]
    private void Construct(PlayerEntity player)
    {
        this.player = player.transform;
    }
    
    private void Start()
    {
        angularSpeed = Random.Range(0, speed);
        angularDirection = Math.Sign(Random.Range(-1, 1));
    }

    private void Update()
    {
        if (!player) return;
        var directionTowardsPlayer = player.position - transform.position;
        ChasePlayer(directionTowardsPlayer);
        GoAroundPlayer();
    }

    private void ChasePlayer(Vector3 directionTowardsPlayer)
    {
        transform.position += directionTowardsPlayer.GetDirectionWithSpeed(speed);
    }

    private void GoAroundPlayer()
    {
        var playerToEnemy = transform.position - player.position;
        var orthogonal = Vector3.Cross(playerToEnemy, Vector3.forward);
        var playerToEnemyDistance = playerToEnemy.magnitude;

        if (noSurroundDistance <= playerToEnemyDistance && playerToEnemyDistance <= beginSurroundDistance)
        {
            transform.position += angularDirection * orthogonal.GetDirectionWithSpeed(angularSpeed);
        }
    }
}