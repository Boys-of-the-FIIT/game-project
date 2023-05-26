using System;
using System.Collections;
using Player;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Utils;

namespace DefaultNamespace.Abilities
{
    public class Pacifier : Ability
    {
        public override void Invoke()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(var collider in colliders)
            {
                if (collider.gameObject.CompareTag(Tags.Enemy))
                    collider.gameObject.GetComponent<Enemy>().Die();
            }
        }
    }
}