using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(menuName = "Soap/ScriptableEvents/ResourceCollectedEvent")]
public class ResourceCollectedEvent : ScriptableEvent<ResourceCollectedEvent.ResourceData>
{
    // This struct carries the data for the event, such as resource type and amount
    [System.Serializable]
    public struct ResourceData
    {
        public string resourceName;
        public int amountCollected;
    }
}