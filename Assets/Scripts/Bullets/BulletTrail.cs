using System;
using UnityEngine;

namespace Bullets
{
    public class BulletTrail : MonoBehaviour
    {
        [SerializeField] private BulletTrailScriptableObject trailConfig;
        [SerializeField] private Renderer renderer;
        
        private TrailRenderer trail;
        private bool isDisabling;
        private Vector3 _startPosition;
        private const string DISABLE_METHOD_NAME = "Disable";
        private const string DO_DISABLE_METHOD_NAME = "DoDisable";
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            trail = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            renderer.enabled = true;
            CancelInvoke(DISABLE_METHOD_NAME);
            ConfigureTrail();
            Invoke(DISABLE_METHOD_NAME, 2);
        }

        private void ConfigureTrail()
        {
            if (trail is not null && trailConfig is not null)
            {
                trailConfig.SetUpTrail(trail);
            }
        }

        protected void Disable()
        {
            CancelInvoke(DISABLE_METHOD_NAME);
            CancelInvoke(DO_DISABLE_METHOD_NAME);
            rb.velocity = Vector3.zero;
            renderer.enabled = false;

            if (trail is not null && trailConfig is not null)
            {
                isDisabling = true;
                Invoke(DO_DISABLE_METHOD_NAME, trailConfig.durationTime);
            }
            else
            {
                DoDisable();
            }
        }

        private void DoDisable()
        {
            if (trail is not null && trailConfig is not null)
            {
                trail.Clear();
            }

            gameObject.SetActive(false);
        }
    }
}