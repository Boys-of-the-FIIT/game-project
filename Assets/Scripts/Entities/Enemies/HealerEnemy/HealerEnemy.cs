using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Utils;

namespace Enemies.HealerEnemy
{
    public class HealerEnemy : Enemy
    {
        [SerializeField] internal int healDelaySeconds;
        [SerializeField] internal int healPoints;
        [SerializeField] internal float healDistance;
        [SerializeField] internal float searchForTargetDistance; 

        private StateMachine stateMachine;
        
        internal Enemy HealTarget { get; set; }
        
        internal bool CanHeal { get; set; }
        
        private void Awake()
        {
            CanHeal = true;
            var searchForInjured = new SearchForInjuredEnemyState(this);
            var followTarget = new FollowTargetState(this);
            var healTarget = new HealTargetState(this);
            var restoreHealAbility = new RestoreHealAbilityState(this);
            
            stateMachine = new StateMachine();
            
            stateMachine.AddTransition(searchForInjured, followTarget, HasTarget());
            stateMachine.AddTransition(followTarget, healTarget, ReachedTarget());
            stateMachine.AddTransition(healTarget, restoreHealAbility, () => true);
            stateMachine.AddTransition(restoreHealAbility, searchForInjured, HasHealAbility());
            
            stateMachine.AddTransition(followTarget, searchForInjured, NoTarget());
            stateMachine.AddTransition(healTarget, searchForInjured, NoTarget());
            
            stateMachine.SetState(searchForInjured);

            Func<bool> HasHealAbility() => () => CanHeal;
            Func<bool> HasTarget() => () => HealTarget != null;
            Func<bool> NoTarget() => () => HealTarget == null;
            Func<bool> ReachedTarget() => () =>
                Vector2.Distance(HealTarget.transform.position, transform.position) <= healDistance;
        }

        private void Update() => stateMachine.Tick();
    }
}