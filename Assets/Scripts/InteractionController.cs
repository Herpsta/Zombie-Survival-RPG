using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [Tooltip("Tag for the door object")]
    public string doorTag = "Door"; // Expose the door tag in the inspector for customization

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the door tag
        if (other.CompareTag(doorTag))
        {
            HandleDoorInteraction();
        }
        // TODO: Add more interaction triggers for other objects
    }

    private void HandleDoorInteraction()
    {
        // TODO: Implement door opening logic here
    }

    // TODO: Add methods for other interactions like accessing containers, etc.
}