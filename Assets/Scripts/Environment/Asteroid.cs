using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public AsteroidStats stats; // Reference to the asteroid stats ScriptableObject
    public AsteroidSizeConfig sizeConfig; // Reference to the size config ScriptableObject
    public PlayerScore playerScore; // Reference to the player's score
    public AsteroidSpawner asteroidSpawner; // Reference to the spawner for creating new asteroids
    [SerializeField]
    private int currentHealth;
    private bool isDestroyed = false; // Flag to prevent multiple destructions
    private Camera mainCamera;
    private Vector3 screenBottomLeft;
    private Vector3 screenTopRight;

    private void Start()
    {
        // Ensure the AsteroidSpawner reference is set
        if (asteroidSpawner == null)
        {
            asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
            if (asteroidSpawner == null)
            {
                Debug.LogError("AsteroidSpawner not found in the scene. Please assign it in the Inspector or ensure it exists in the scene.");
            }
        }

        // Ensure the PlayerScore reference is set
        if (playerScore == null)
        {
            playerScore = FindObjectOfType<PlayerScore>();
            if (playerScore == null)
            {
                Debug.LogError("PlayerScore not found in the scene. Please assign it in the Inspector or ensure it exists in the scene.");
            }
        }

        // Ensure the SizeConfig reference is set
        if (sizeConfig == null)
        {
            Debug.LogError("SizeConfig not assigned to the asteroid. Please ensure it is assigned in the Inspector.");
        }

        mainCamera = Camera.main;
        CalculateScreenBounds();
    }

    private void Update()
    {
        HandleWrapAround(); // Handle wrapping around the screen
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Prevent multiple collisions from the same projectile
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile != null && projectile.hasHitTarget)
            {
                return; // If the projectile has already hit a target, exit the method
            }

            // Mark the projectile as having hit the target
            if (projectile != null)
            {
                projectile.hasHitTarget = true;
            }

            // Apply damage and destroy the projectile
            TakeDamage(projectile.settings.damage);

            // Disable the collider to prevent further collisions before destroying the projectile
            collision.gameObject.GetComponent<Collider>().enabled = false;
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDestroyed) return; // Prevent further damage if already destroyed

        currentHealth -= damage;
        Debug.Log($"Current Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            DestroyAsteroid();
        }
    }

    private void DestroyAsteroid()
    {
        if (isDestroyed) return; // Ensure this method is only called once

        isDestroyed = true;

        // Ensure PlayerScore reference is available
        if (playerScore == null)
        {
            Debug.LogError("PlayerScore reference is missing. Cannot add points.");
            return;
        }

        // Apply points based on scale (small, medium, large)
        float pointsMultiplier = GetPointsMultiplierBasedOnScale();
        playerScore.Value += Mathf.RoundToInt(stats.basePoints * pointsMultiplier);

        // Spawn smaller asteroids if applicable
        if (IsLargeAsteroid())
        {
            SpawnSmallerAsteroids(2, sizeConfig.mediumSizeRange); // Always spawn 2 medium asteroids
        }
        else if (IsMediumAsteroid())
        {
            SpawnSmallerAsteroids(3, sizeConfig.smallSizeRange); // Always spawn 3 small asteroids
        }

        Destroy(gameObject);
    }

    private void SpawnSmallerAsteroids(int count, int sizeRange)
    {
        if (asteroidSpawner == null)
        {
            Debug.LogError("AsteroidSpawner reference is missing. Cannot spawn smaller asteroids.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            // Ensure each spawned asteroid is of the correct size
            Vector3 spawnScale = Vector3.one * sizeRange;
            asteroidSpawner.SpawnAsteroid(transform.position, spawnScale);
        }
    }

    public void SetHPBasedOnSize()
    {
        if (IsLargeAsteroid())
        {
            currentHealth = stats.healthPoints;
        }
        else if (IsMediumAsteroid())
        {
            currentHealth = stats.healthPoints - 1;
        }
        else
        {
            currentHealth = stats.healthPoints - 2;
        }
    }

    private bool IsLargeAsteroid()
    {
        float currentScale = transform.localScale.x; // Assuming uniform scaling on all axes
        bool isLarge = currentScale == sizeConfig.largeSizeRange ? true : false;
        return isLarge;
    }

    private bool IsMediumAsteroid()
    {
        float currentScale = transform.localScale.x; // Assuming uniform scaling on all axes
        bool isMedium = currentScale == sizeConfig.mediumSizeRange ? true : false;
        return isMedium;
    }

    private float GetPointsMultiplierBasedOnScale()
    {
        if (IsLargeAsteroid()) return sizeConfig.largePointsMultiplier;
        if (IsMediumAsteroid()) return sizeConfig.mediumPointsMultiplier;
        return sizeConfig.smallPointsMultiplier;
    }

    // Handles wrapping the asteroid around the screen
    private void HandleWrapAround()
    {
        Vector3 newPosition = transform.position;

        if (newPosition.x > screenTopRight.x) newPosition.x = screenBottomLeft.x;
        else if (newPosition.x < screenBottomLeft.x) newPosition.x = screenTopRight.x;

        if (newPosition.z > screenTopRight.z) newPosition.z = screenBottomLeft.z;
        else if (newPosition.z < screenBottomLeft.z) newPosition.z = screenTopRight.z;

        transform.position = newPosition;
    }

    // Calculates screen bounds in world coordinates based on the camera's viewport
    private void CalculateScreenBounds()
    {
        screenBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.y));
        screenTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.y));
    }
}
