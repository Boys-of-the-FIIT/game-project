using Player;
using UnityEngine;
using Zenject;

public class Hide : MonoBehaviour
{
    private PlayerEntity player;

    private SpriteRenderer[] spriteRenderers;
    private Canvas healthBarCanvas;
    
    [SerializeField] private float hidingCoefficient = 1;

    [SerializeField] private float startIdlingDistance = 10;
    [SerializeField] private float startHidingDistance = 20;

    [Inject]
    private void Construct(PlayerEntity player)
    {
        this.player = player;
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        healthBarCanvas = gameObject.GetComponentInChildren<Canvas>();
    }

    private void FixedUpdate()
    {
        var distanceToPlayer = (player.transform.position - transform.position).magnitude;

        if (distanceToPlayer < startIdlingDistance)
        {
            DoIdling();
        }

        if (distanceToPlayer < startHidingDistance)
        {
            DoHiding();
        }
        else
        {
            Unhide();
        }
    }

    private void DoHiding()
    {
        healthBarCanvas.enabled = false;
        
        StopMovement();
        
        foreach (var spriteRenderer in spriteRenderers)
        {
            var currentColor = spriteRenderer.color;
            var newColor = new Color(
                currentColor.r,
                currentColor.g,
                currentColor.b,
                currentColor.a - hidingCoefficient / 1000f
            );

            spriteRenderer.color = newColor;
        }
    }

    private void StopMovement()
    {
        // TODO
    }

    // Unhide should also be called when the entity starts moving
    private void Unhide()
    {
        healthBarCanvas.enabled = true;
        
        foreach (var spriteRenderer in spriteRenderers)
        {
            var currentColor = spriteRenderer.color;
            var newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);

            spriteRenderer.color = newColor;
        }
    }

    // DoIdling should be called when player is too close to the entity
    private void DoIdling()
    {
        StopShooting();
    }

    private void StopShooting()
    {
        // TODO
    }
}