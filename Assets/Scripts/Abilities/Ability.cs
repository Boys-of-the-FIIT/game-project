using System.Collections;
using Player;
using UnityEngine;
using Utils;
using Zenject;

namespace DefaultNamespace.Abilities
{
    public abstract class Ability : MonoBehaviour
    {
        private Transform player;
        [SerializeField] private protected float radius;
        [SerializeField] private protected KeyCode activationButton;
        [SerializeField] private float coolDown;
        private bool canInvoke = true;
    
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(activationButton) && canInvoke)
                StartCoroutine(InvokeCoroutine());
        }

        public IEnumerator InvokeCoroutine()
        {
            Invoke();
            canInvoke = false;
            yield return new WaitForSeconds(coolDown);
            canInvoke = true;
        }

        public abstract void Invoke();
    }
}