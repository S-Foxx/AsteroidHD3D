using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CheckpointReachedEvent checkpointReachedEvent; // Reference to the checkpoint event
    private int currentLevel = 1;

    public void CompleteLevel()
    {
        // Logic for completing a level
        currentLevel++;

        // Check if it's a checkpoint level
        if (IsCheckpointLevel())
        {
            // Trigger the checkpoint reached event
            checkpointReachedEvent?.Raise(currentLevel);

            // Apply difficulty modifiers
            ApplyDifficultyModifiers();
        }

        // Load the next level
        LoadNextLevel();
    }

    private bool IsCheckpointLevel()
    {
        // Determine if the current level is a checkpoint level
        return currentLevel % 3 == 0; // Example: every 3rd level is a checkpoint
    }

    private void ApplyDifficultyModifiers()
    {
        // Logic to increase difficulty (e.g., faster asteroids, stronger enemies)
        Debug.Log("Difficulty increased!");
    }

    private void LoadNextLevel()
    {
        // Logic to load the next level
        Debug.Log("Loading next level...");
    }
}
