using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint; // Point where the projectile is fired from
    public ProjectileSettings projectileSettings; // Reference to the projectile settings

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectileComponent = projectile.GetComponent<Projectile>();
        projectileComponent.settings = projectileSettings; // Assign the settings
    }
}
