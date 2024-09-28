using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Soap/ScriptableObjects/AsteroidSpawnConfig")]
public class AsteroidSpawnConfig : ScriptableObject
{
    public List<AsteroidStats> asteroidPrefabs; // List of potential asteroid prefabs to spawn
    public float smallAsteroidChance = 0.5f; // Chance for small asteroid
    public float mediumAsteroidChance = 0.3f; // Chance for medium asteroid
    public float largeAsteroidChance = 0.2f; // Chance for large asteroid
}
