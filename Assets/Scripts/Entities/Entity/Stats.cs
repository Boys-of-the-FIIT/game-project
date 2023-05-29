using UnityEngine;

namespace DefaultNamespace
{
    public class Stats : MonoBehaviour
    {
        private int currentHealth;

        public int CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = value;
        }
        
        [SerializeField] private int maxHealth;

        public int MaxHealth
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
        
        [SerializeField] private int damage;

        public int Damage
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
    }
}