using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AsteroidSpawnChanceConfig")]
public class AsteroidSpawnChanceConfig : ScriptableObject
{
    public List<AsteroidSpawnChance> asteroidSpawnChances;

    private void OnValidate()
    {
        AdjustSpawnChances();
    }

    private void AdjustSpawnChances()
    {
        float totalChance = 0;

        // Calculate total current chance
        foreach (var chance in asteroidSpawnChances)
        {
            totalChance += chance.spawnChance;
        }

        // Adjust spawn chances to add up to 100%
        if (totalChance > 0)
        {
            for (int i = 0; i < asteroidSpawnChances.Count; i++)
            {
                asteroidSpawnChances[i].spawnChance = (asteroidSpawnChances[i].spawnChance / totalChance) * 100f;
            }
        }
    }
}