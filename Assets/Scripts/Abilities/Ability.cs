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

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
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
            yield return new WaitForSeconds(coolDown);
            canInvoke = true;
        }

        public abstract void Invoke();
    }
}