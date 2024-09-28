using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(menuName = "Soap/ScriptableEvents/PlayerDamagedEvent")]
public class PlayerDamagedEvent : ScriptableEvent<int>
{
    // This event carries an integer representing the remaining player health after damage
}