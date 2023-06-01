using DefaultNamespace;
using Player;
using UnityEngine;
using Zenject;

namespace UI.Scripts
{
    public class StatsUpgrader : MonoBehaviour
    {
        private Stats Stats;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.Stats = player.Stats;
        }

        public void AddMaxHealth(float health)
        {
            Stats.MaxHealth += health;
            Stats.CurrentHealth = Stats.MaxHealth;
        }

        public void AddSpeed(float speed) => Stats.Speed += speed;
        public void AddDamage(float damage) => Stats.Damage += damage;
        public void DecreaseRecoilAngle(float angle) => Stats.RecoilAngle -= angle;
        public void AddBulletSpeed(float bulletSpeed) => Stats.BulletSpeed -= bulletSpeed;
        public void DecreaseReloadTime(float reloadTime) => Stats.ReloadTime -= reloadTime;
        public void AddAttackDistance(float attackDistance) => Stats.AttackDistance -= attackDistance;
    }
}