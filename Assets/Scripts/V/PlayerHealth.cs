using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(menuName = "Soap/ScriptableVariables/PlayerHealth")]
public class PlayerHealth : ScriptableVariable<int>
{
    // Reference to the PlayerDamagedEvent
    public PlayerDamagedEvent playerDamagedEvent;

    private void OnEnable()
    {
        Value = 100; // Default starting health
    }

    public void TakeDamage(int damage)
    {
        Value -= damage;
        if (Value < 0) Value = 0;

        // Trigger the PlayerDamaged event, passing the current health value
        if (playerDamagedEvent != null)
        {
            playerDamagedEvent.Raise(Value);
        }
    }

    public void Heal(int healAmount)
    {
        Value += healAmount;
        if (Value > 100) Value = 100; // Clamp health to max value
    }
}
