using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(menuName = "Soap/ScriptableEvents/AsteroidDestroyedEvent")]
public class AsteroidDestroyedEvent : ScriptableEvent<int>
{
    // This event is triggered when an asteroid is destroyed.
    // The integer passed represents the type of resource it drops.
}
