using UnityEngine;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidSpawnChanceConfig spawnChanceConfig; // Reference to the new spawn chance config
    public AsteroidSizeConfig sizeConfig; // Reference to the size config
    public PlayerScore playerScore; // Reference to the player's score
    public int numberOfAsteroids = 10; // Number of asteroids to spawn initially
    public float minSpeed = 1f; // Minimum speed of asteroids
    public float maxSpeed = 5f; // Maximum speed of asteroids
    int initCounter = 0;
    private Camera mainCamera;
    private Vector3 screenBottomLeft;
    private Vector3 screenTopRight;

    private void Start()
    {
        mainCamera = Camera.main;
        CalculateScreenBounds();
        SpawnInitialAsteroids();
        Debug.Log("Init: " + initCounter);
        initCounter++;
    }

    // Calculate screen bounds in world coordinates based on the camera's viewport
    private void CalculateScreenBounds()
    {
        screenBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.y));
        screenTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.y));
    }

    private void SpawnInitialAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            SpawnAsteroid(); // Spawn initial asteroids
        }
    }

    public void SpawnAsteroid(Vector3? spawnPositionOverride = null, Vector3? sizeOverride = null)
    {
        AsteroidStats selectedAsteroid = GetRandomAsteroid();

        if (selectedAsteroid != null)
        {
            // Determine spawn position
            Vector3 spawnPosition = spawnPositionOverride ?? GetRandomSpawnPosition();

            // Determine asteroid size based on initial spawn rules (or override if splitting)
            Vector3 asteroidScale = sizeOverride ?? DetermineInitialAsteroidScale();

            // Instantiate the asteroid
            GameObject asteroid = Instantiate(selectedAsteroid.asteroidPrefab, spawnPosition, Quaternion.identity);

            // Set the scale of the asteroid
            asteroid.transform.localScale = asteroidScale;

            // Set random velocity and direction
            Rigidbody rb = asteroid.GetComponent<Rigidbody>();
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            float speed = Random.Range(minSpeed, maxSpeed);
            rb.velocity = direction * speed;

            // Assign references to the asteroid
            Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
            asteroidScript.stats = selectedAsteroid;
            asteroidScript.sizeConfig = sizeConfig;
            asteroidScript.playerScore = playerScore; // Assign the player score reference
            asteroidScript.asteroidSpawner = this;
            asteroidScript.SetHPBasedOnSize();
        }
    }

    private Vector3 DetermineInitialAsteroidScale()
    {
        float randomValue = Random.value;
        if (randomValue <= 0.2f) return Vector3.one * sizeConfig.largeSizeRange;
        if (randomValue <= 0.3f) return Vector3.one * sizeConfig.mediumSizeRange;
        return Vector3.one * sizeConfig.smallSizeRange;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(screenBottomLeft.x, screenTopRight.x);
        float randomZ = Random.Range(screenBottomLeft.z, screenTopRight.z);
        return new Vector3(randomX, 0f, randomZ); // Spawn on XZ plane
    }

    public AsteroidStats GetRandomAsteroid()
    {
        float totalWeight = 0;
        foreach (var chance in spawnChanceConfig.asteroidSpawnChances)
        {
            totalWeight += chance.spawnChance;
        }

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        foreach (var chance in spawnChanceConfig.asteroidSpawnChances)
        {
            cumulativeWeight += chance.spawnChance;
            if (randomValue <= cumulativeWeight)
            {
                return chance.asteroid;
            }
        }

        return null;
    }
}
