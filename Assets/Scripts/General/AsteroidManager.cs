using UnityEngine;
using Obvious.Soap;

public class AsteroidManager : MonoBehaviour
{
    public ActiveAsteroids activeAsteroids; // Reference to the ScriptableList<Asteroid>

    // This method adds an asteroid to the active list
    public void AddAsteroid(Asteroid asteroid)
    {
        activeAsteroids.Add(asteroid);
    }

    // This method removes an asteroid from the active list
    public void RemoveAsteroid(Asteroid asteroid)
    {
        activeAsteroids.Remove(asteroid);
    }

    // Other logic for spawning, managing, and destroying asteroids...
}
