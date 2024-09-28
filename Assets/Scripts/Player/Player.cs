using UnityEngine;
using TMPro; // For updating the UI
using Obvious.Soap; // For SOAP Variables

public class Player : MonoBehaviour
{
    public PlayerHealthConfig healthConfig; // Reference to the health config ScriptableObject
    public PlayerHealth playerHealth; // SOAP variable for tracking current health
    public TMP_Text healthText; // Reference to the health UI Text

    private Camera mainCamera;

    private void Start()
    {
        // Initialize player's health using the maxHealth from healthConfig
        playerHealth.Value = healthConfig.maxHealth;
        UpdateHealthUI(); // Update UI

        mainCamera = Camera.main; // Get the main camera reference
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        playerHealth.Value -= healthConfig.damagePerHit; // Deduct health by damage per hit
        UpdateHealthUI(); // Update UI

        if (playerHealth.Value <= 0)
        {
            Debug.Log("Game Over"); // Placeholder for game over
        }
        else
        {
            TeleportToRandomLocation(); // Teleport the player if still alive
        }
    }

    private void UpdateHealthUI()
    {
        healthText.text = "Health: " + playerHealth.Value; // Update the health display
    }

    private void TeleportToRandomLocation()
    {
        Vector3 newPosition;
        int maxAttempts = 100; // Max attempts to find a clear spot
        bool clearSpotFound = false;

        for (int i = 0; i < maxAttempts; i++)
        {
            newPosition = GetRandomPositionWithinScreenBounds();

            // Check if the new position is clear of other objects
            if (!Physics.CheckSphere(newPosition, 1f)) // Assuming a radius of 1 unit for checking collisions
            {
                transform.position = newPosition; // Move the player to the new position
                clearSpotFound = true;
                break;
            }
        }

        if (!clearSpotFound)
        {
            Debug.LogWarning("Failed to find a clear spot after 100 attempts.");
        }
    }

    private Vector3 GetRandomPositionWithinScreenBounds()
    {
        Vector3 screenBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.y));
        Vector3 screenTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.y));

        float randomX = Random.Range(screenBottomLeft.x, screenTopRight.x);
        float randomZ = Random.Range(screenBottomLeft.z, screenTopRight.z);

        return new Vector3(randomX, 0f, randomZ); // Return the random position on the XZ plane
    }
}
