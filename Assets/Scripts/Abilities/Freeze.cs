using UnityEngine;
using Utils;

namespace DefaultNamespace.Abilities
{
    public class Freeze : Ability
    {
        
        public override void Invoke()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(var collider in colliders)
            {
                if (collider.gameObject.CompareTag(Tags.Enemy))
                {
                    
                }
            }
        }
    }
}