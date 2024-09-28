using UnityEngine;

public enum AsteroidSize
{
    Small,
    Medium,
    Large
}

[CreateAssetMenu(menuName = "ScriptableObjects/AsteroidStats")]
public class AsteroidStats : ScriptableObject
{
    public GameObject asteroidPrefab; // Reference to the asteroid prefab
    public int basePoints; // Base points awarded for destroying the asteroid
    public bool containsResources; // Does this asteroid contain resources?
    public float spawnChance; // Chance of this asteroid being selected during spawning

    public int healthPoints; // Health points of the asteroid

    [HideInInspector] public AsteroidSize sizeClass; // The size class of the asteroid
}
