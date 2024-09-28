using UnityEngine;

public class Resource : MonoBehaviour
{
    public int resourceType; // The type of resource (e.g., 0 for Iron)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collects the resource
        if (other.CompareTag("Player"))
        {
            CollectResource();
        }
    }

    private void CollectResource()
    {
        // Logic to add the resource to the player's inventory
        Debug.Log("Resource collected: " + resourceType);
        // You would typically call some resource manager here to add the resource.

        // Destroy the resource object
        Destroy(gameObject);
    }
}
