using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerMovementSettings")]
public class PlayerMovementSettings : ScriptableObject
{
    public float thrustPower = 200f; // Power of the thrust
    public float rotationSpeed = 200f; // Speed of rotation
    public float maxSpeed = 750f; // Maximum speed the player can reach
}
