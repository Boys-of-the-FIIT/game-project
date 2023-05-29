using Player;
using UnityEngine;
using Zenject;


namespace DefaultNamespace
{
    public class AssassinEnemy : Enemy
    {
        private PlayerEntity player;
        
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }
    }
}