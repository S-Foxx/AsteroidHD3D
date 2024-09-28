using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public IronResource ironResource; // Reference to the Iron resource scriptable variable
    public RedResource redResource; // Reference to the Red resource scriptable variable
    // Add references to the other resource types

    public void CraftWeaponUpgrade()
    {
        // Example upgrade that costs resources
        int ironCost = 10;
        int redCost = 5;

        if (ironResource.Value >= ironCost && redResource.Value >= redCost)
        {
            // Spend resources
            ironResource.SpendResource(ironCost);
            redResource.SpendResource(redCost);

            // Apply the upgrade (e.g., increase player weapon damage)
            ApplyWeaponUpgrade();
        }
        else
        {
            // Notify the player that they don't have enough resources
            Debug.Log("Not enough resources to craft the weapon upgrade.");
        }
    }

    private void ApplyWeaponUpgrade()
    {
        // Logic to upgrade the player's weapon
        Debug.Log("Weapon upgraded!");
    }
}
