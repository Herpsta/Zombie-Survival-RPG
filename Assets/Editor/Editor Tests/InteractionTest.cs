using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class InteractionTest : MonoBehaviour
{
    // Tooltip for the door prefab
    [Tooltip("Prefab for the door to be tested")]
    public GameObject doorPrefab;

    // Tooltip for the player prefab
    [Tooltip("Prefab for the player to be tested")]
    public GameObject playerPrefab;

    [UnityTest]
    public IEnumerator CanOpenDoor()
    {
        // Instantiate door and player
        GameObject door = Instantiate(doorPrefab);
        GameObject player = Instantiate(playerPrefab);

        // Simulate interaction
        // TODO: Implement the interaction between the player and the door

        // Wait for a frame to give time for the interaction to occur
        yield return null;

        // Check if the door is open
        // TODO: Implement the isOpen property in the door's script
        // Assert.IsTrue(door.GetComponent<DoorScript>().isOpen);
    }

    // TODO: Add more tests for other interactions like accessing containers, etc.
}