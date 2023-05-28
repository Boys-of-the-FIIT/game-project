using System;
using System.Collections;
using Player;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Abilities
{
    public class Dash : Ability
    {
        [Inject] private PlayerEntity player;
        
        private Rigidbody2D playerRb;
        
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