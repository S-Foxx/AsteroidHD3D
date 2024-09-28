using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileSettings")]
public class ProjectileSettings : ScriptableObject
{
    public float speed = 200f; // Speed of the projectile
    public float lifetime = 5f; // Lifetime in seconds before the projectile is destroyed
    public int damage = 34; //Base Damaged applied to asteroid
}
