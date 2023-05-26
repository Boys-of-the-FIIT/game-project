using System.Collections;
using UnityEngine;
using Utils;

namespace DefaultNamespace.Abilities
{
    public class Ability : MonoBehaviour
    {
        private Transform player;
        [SerializeField] private protected float radius;
        [SerializeField] private float coolDown;
        private bool canInvoke = true;
        
        
        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player).transform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && canInvoke)
                StartCoroutine(InvokeCoroutine());
        }

        public IEnumerator InvokeCoroutine()
        {
            Invoke();
            canInvoke = false;
            yield return new WaitForSeconds(coolDown);
            canInvoke = true;
        }

        public virtual void Invoke() { }
    }
}