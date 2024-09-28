using UnityEngine;
using Obvious.Soap;
using System;

[CreateAssetMenu(menuName = "Soap/ScriptableEvents/CheckpointReachedEvent")]
public class CheckpointReachedEvent : ScriptableEvent<int>
{
    // This event is triggered when the player reaches a checkpoint
    // Additional logic for handling difficulty modifiers can be added here
}