using System;
using System.Collections;
using Player;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Abilities
{
    public abstract class Ability : MonoBehaviour
    {
        [SerializeField] private protected float radius;
        [SerializeField] private protected KeyCode activationButton;
        [SerializeField] private protected float coolDown;

        private protected PlayerEntity player;
        private protected bool canInvoke = true;
        private float currentCooldownTime;

        public float CurrentCooldownTimes
        {
            get => currentCooldownTime;
            set => currentCooldownTime = value;
        }

        public float CoolDown => coolDown;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }

        private void Start()
        {
            currentCooldownTime = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(activationButton) && canInvoke)
                StartCoroutine(InvokeCoroutine());
        }

        public virtual IEnumerator InvokeCoroutine()
        {
            Invoke();
            canInvoke = false;
            
            while (currentCooldownTime < CoolDown)
            {
                currentCooldownTime += Time.deltaTime;
                yield return null;
            }

            currentCooldownTime = 0;
            canInvoke = true;
        }

        public abstract void Invoke();
    }
}