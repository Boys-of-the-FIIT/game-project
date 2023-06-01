using UnityEngine;

namespace DefaultNamespace
{
    public class Stats : MonoBehaviour
    {
        private float currentHealth;

        public float CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = value;
        }
        
        [SerializeField] private float maxHealth;

        public float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        [SerializeField] private float speed;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        
        [SerializeField] private float damage;

        public float Damage
        {
            get => damage;
            set => damage = value;
        }
        
        [Range(0, 180)] [SerializeField] private float recoilAngle;
        
        public float RecoilAngle
        {
            get => recoilAngle;
            set => recoilAngle = value;
        }
        

        [SerializeField] private float bulletSpeed;
        
        public float BulletSpeed
        {
            get => bulletSpeed;
            set => bulletSpeed = value;
        }
        
        [SerializeField] private float reloadTime;
        
        public float ReloadTime
        {
            get => reloadTime;
            set => reloadTime = value;
        }
        
        [SerializeField] private float attackDistance;
        
        public float AttackDistance
        {
            get => attackDistance;
            set => attackDistance = value;
        }
        
        [SerializeField] private int upgradePoints;
        
        public int UpgradePoints
        {
            get => upgradePoints;
            set => upgradePoints = value;
        }
    }
}