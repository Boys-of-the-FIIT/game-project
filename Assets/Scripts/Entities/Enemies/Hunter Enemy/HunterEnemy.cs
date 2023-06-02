using System;
using Enemies.HunterEnemy.States;
using Player;
using UnityEngine;
using Zenject;

namespace Enemies.HunterEnemy
{

    public class HunterEnemy : Enemy
    {
        
        [SerializeField] internal float hidingCoefficient = 1;
        [SerializeField] internal float startIdlingDistance = 10;
        [SerializeField] internal float startHidingDistance = 20;

        internal SpriteRenderer[] spriteRenderers;
        internal Canvas healthBarCanvas;

        private PlayerEntity player;
        private EnemyAttack attack;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
            spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
            healthBarCanvas = gameObject.GetComponentInChildren<Canvas>();
            attack = GetComponentInChildren<EnemyAttack>();
        }

        private StateMachine stateMachine;

        private float DistanceToPlayer => (player.transform.position - transform.position).magnitude;

        private void FixedUpdate()
        {
            var distanceToPlayer = (player.transform.position - transform.position).magnitude;

            attack.enabled = distanceToPlayer > startIdlingDistance;

            if (distanceToPlayer < startHidingDistance)
                DoHiding();
            else
                UndoHide();
        }
        
        private void DoHiding()
        {
            healthBarCanvas.enabled = false;

            foreach (var spriteRenderer in spriteRenderers)
            {
                var currentColor = spriteRenderer.color;
                var newColor = new Color(
                    currentColor.r,
                    currentColor.g,
                    currentColor.b,
                    currentColor.a - hidingCoefficient / 250f
                );

                spriteRenderer.color = newColor;
            }
        }

        private void UndoHide()
        {
            healthBarCanvas.enabled = true;

            foreach (var spriteRenderer in spriteRenderers)
            {
                var currentColor = spriteRenderer.color;
                var newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);

                spriteRenderer.color = newColor;
            }
        }
    }
}