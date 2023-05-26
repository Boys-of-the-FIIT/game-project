using System.Collections;
using UnityEngine;
using Utils;

namespace DefaultNamespace.Abilities
{
    public class Freeze : Ability
    {
        [SerializeField] private float freezeTime;
        
        public override void Invoke()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(var collider in colliders)
            {
                if (collider.gameObject.CompareTag(Tags.Enemy))
                {
                    StartCoroutine(FreezeObjectForTimePeriod(collider.gameObject, freezeTime));
                }
            }
        }
        
        private IEnumerator FreezeObjectForTimePeriod(GameObject gameObject, float seconds)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(true);
        }
    }
}