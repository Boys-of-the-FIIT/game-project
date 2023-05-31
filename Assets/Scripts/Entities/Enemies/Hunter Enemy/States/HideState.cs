using UnityEngine;

namespace Enemies.HunterEnemy.States
{
    public class HideState : IState
    {
        private HunterEnemy hunter;
        
        public HideState(HunterEnemy hunter)
        {
            this.hunter = hunter;
        }
        
        public void OnEnter()
        {
            hunter.healthBarCanvas.enabled = false;
        }
        
        public void Tick()
        {
            foreach (var spriteRenderer in hunter.spriteRenderers)
            {
                var currentColor = spriteRenderer.color;
                var newColor = new Color(
                    currentColor.r,
                    currentColor.g,
                    currentColor.b,
                    currentColor.a - hunter.hidingCoefficient / 1000f
                );

                spriteRenderer.color = newColor;
            }
        }

        public void OnExit()
        {
            
        }
    }
}