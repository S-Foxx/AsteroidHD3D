using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AsteroidSizeConfig")]
public class AsteroidSizeConfig : ScriptableObject
{
    [Header("Size Ranges")]
    public int smallSizeRange = 10; // scale for small asteroids
    public int mediumSizeRange = 25;  // scale for medium asteroids
    public int largeSizeRange = 50;   // scale for large asteroids

    [Header("Multipliers")]
    public float smallPointsMultiplier = 1f; // Multiplier for points from small asteroids
    public float mediumPointsMultiplier = 2f; // Multiplier for points from medium asteroids
    public float largePointsMultiplier = 3f; // Multiplier for points from large asteroids

    public float smallResourceMultiplier = 1f; // Multiplier for resources from small asteroids
    public float mediumResourceMultiplier = 2f; // Multiplier for resources from medium asteroids
    public float largeResourceMultiplier = 3f; // Multiplier for resources from large asteroids
}
