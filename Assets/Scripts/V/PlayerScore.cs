
using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(menuName = "Soap/ScriptableVariables/PlayerScore")]
public class PlayerScore : ScriptableVariable<int>
{
    // This scriptable variable tracks the player's score.
    // When asteroids are destroyed, points will be added to this variable.
}
