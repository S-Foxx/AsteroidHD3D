using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(menuName = "Soap/ScriptableVariables/RedResource")]
public class RedResource : ScriptableVariable<int>
{
    // This variable stores the player's current Iron resource count.
    // When the value changes, it will automatically trigger the OnValueChanged event.

    private void OnEnable()
    {
        // Initialize the resource count (could be loaded from saved data).
        Value = 0; // Default starting value
    }

    public void AddResource(int amount)
    {
        Value += amount;
        // Additional logic can be added here if needed (e.g., capping resource limits).
    }

    public void SpendResource(int amount)
    {
        Value -= amount;
        // Ensure the resource count doesn't go negative
        if (Value < 0) Value = 0;
    }
}