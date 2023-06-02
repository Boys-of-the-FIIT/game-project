namespace Enemies.HunterEnemy.States
{
    public class ActiveState : IState
    {
        public void Tick()
        {
            
        }

        public void OnEnter()
        {
            // attack = hunter.GetComponentInChildren<EnemyAttack>();
            // if (attack is null) return;
            // attack.enabled = false;
        }

        public void OnExit()
        {
            // attack.enabled = true;
        }
    }
}