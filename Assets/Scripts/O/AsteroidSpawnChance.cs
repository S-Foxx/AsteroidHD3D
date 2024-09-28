using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class AsteroidSpawnChance
{
    public AsteroidStats asteroid;
    [Range(0, 100)] public float spawnChance; // Slider to adjust spawn chance
}


