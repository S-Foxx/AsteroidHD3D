using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public CheckpointReachedEvent checkpointReachedEvent; // Reference to the event
    public PlayerHealth playerHealth; // Reference to player's health
    private int currentCheckpoint = 1; // Example checkpoint number

    public void ReachCheckpoint()
    {
        // Trigger the event to notify other systems
        checkpointReachedEvent?.Raise(currentCheckpoint);

        // Apply difficulty modifiers
        ApplyDifficultyModifiers();

        // Heal the player partially or fully as a reward for reaching a checkpoint
        HealPlayer();
    }

    private void ApplyDifficultyModifiers()
    {
        // Increase asteroid speed, strengthen enemies, introduce new hazards, etc.
        // This can be done by modifying relevant scriptable variables or triggering other events
    }

    private void HealPlayer()
    {
        // Optionally, heal the player by a certain amount or fully restore health
        playerHealth.Heal(50); // Heal 50 points, for example
    }
}