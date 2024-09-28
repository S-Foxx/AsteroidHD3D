using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerHealthConfig")]
public class PlayerHealthConfig : ScriptableObject
{
    public int maxHealth = 100; // Max health of the player
    public int damagePerHit = 10; // Damage taken when hit by any asteroid
}
