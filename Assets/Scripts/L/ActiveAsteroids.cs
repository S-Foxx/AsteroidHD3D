using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(menuName = "Soap/ScriptableLists/ActiveAsteroids")]
public class ActiveAsteroids : ScriptableList<Asteroid>
{
    // This list tracks all currently active asteroids in the level.
}
