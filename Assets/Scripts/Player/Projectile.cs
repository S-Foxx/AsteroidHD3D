using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileSettings settings; // Reference to the projectile settings
    private float lifetimeTimer;

    // New flag to track if the projectile has already hit a target
    [HideInInspector]
    public bool hasHitTarget = false;

    private void Start()
    {
        lifetimeTimer = settings.lifetime;
    }

    private void Update()
    {
        // Move the projectile forward along the XZ plane
        transform.position += transform.forward * settings.speed * Time.deltaTime;

        // Decrease lifetime and destroy the projectile when time is up
        lifetimeTimer -= Time.deltaTime;
        if (lifetimeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
