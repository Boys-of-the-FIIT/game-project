using System;
using Player;
using UnityEngine;
using Zenject;

namespace Enemies.HunterEnemy
{
    public class HunterEnemy : Enemy
    {
        [SerializeField] private float hidingCoefficient = 1;
        [SerializeField] private float startIdlingDistance = 10;
        [SerializeField] private float startHidingDistance = 20;

        private SpriteRenderer[] spriteRenderers;
        private Canvas healthBarCanvas;
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
            attack.enabled = DistanceToPlayer > startIdlingDistance;
            if (DistanceToPlayer < startHidingDistance)
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