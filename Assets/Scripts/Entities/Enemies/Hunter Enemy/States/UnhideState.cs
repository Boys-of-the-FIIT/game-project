using UnityEngine;

namespace Enemies.HunterEnemy.States
{
    public class UnhideState : IState
    {
        private HunterEnemy hunter;
        
        public UnhideState(HunterEnemy hunter)
        {
            this.hunter = hunter;
        }
        
        public void Tick()
        {
            hunter.healthBarCanvas.enabled = true;
        
            foreach (var spriteRenderer in hunter.spriteRenderers)
            {
                var currentColor = spriteRenderer.color;
                var newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);

                spriteRenderer.color = newColor;
            }
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}