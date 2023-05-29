using System;
using System.Collections;
using Player;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Abilities
{
    public class Dash : Ability
    {
        private Rigidbody2D playerRb;
        private PlayerEntity player;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }
        
        private void Start()
        {
            playerRb = player.gameObject.GetComponent<Rigidbody2D>();
        }

        public override void Invoke()
        {
            playerRb.velocity = playerRb.velocity * 5;
        }
    }
}