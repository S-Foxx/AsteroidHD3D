using UnityEngine;
using TMPro;
using Obvious.Soap; // Ensure you have the correct SOAP namespace

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the ScoreText UI element
    public TMP_Text healthText; // Reference to the HealthText UI element

    public PlayerScore playerScore; // Reference to the PlayerScore ScriptableVariable
    public PlayerHealth playerHealth; // Reference to the PlayerHealth ScriptableVariable

    private void OnEnable()
    {
        // Subscribe to value changes for both score and health
        playerScore.OnValueChanged += UpdateScoreUI;
        playerHealth.OnValueChanged += UpdateHealthUI;

        // Initialize the UI with current values
        UpdateScoreUI(playerScore.Value);
        UpdateHealthUI(playerHealth.Value);
    }

    private void OnDisable()
    {
        // Unsubscribe from the events to avoid memory leaks
        playerScore.OnValueChanged -= UpdateScoreUI;
        playerHealth.OnValueChanged -= UpdateHealthUI;
    }

    // Method to update the score UI
    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    // Method to update the health UI
    private void UpdateHealthUI(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
    }
}
