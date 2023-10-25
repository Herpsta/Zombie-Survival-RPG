using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerMovementTest : MonoBehaviour
{
    [Tooltip("Player GameObject")]
    public GameObject playerPrefab;
    private GameObject player;
    private PlayerMovement playerMovement;

    [SetUp]
    public void Setup()
    {
        player = Instantiate(playerPrefab);
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    [UnityTest]
    public IEnumerator CanMovePlayerForward()
    {
        Vector3 initialPosition = player.transform.position;

        playerMovement.MoveForward();

        yield return new WaitForSeconds(0.1f);

        Vector3 finalPosition = player.transform.position;

        Assert.Greater(finalPosition.z, initialPosition.z);
    }

    [UnityTest]
    public IEnumerator CanJumpPlayer()
    {
        Vector3 initialPosition = player.transform.position;

        playerMovement.Jump();

        yield return new WaitForSeconds(0.1f);

        Vector3 finalPosition = player.transform.position;

        Assert.Greater(finalPosition.y, initialPosition.y);
    }

    [UnityTest]
    public IEnumerator CanCrouchPlayer()
    {
        float initialHeight = player.transform.localScale.y;

        playerMovement.Crouch();

        yield return null;

        float finalHeight = player.transform.localScale.y;

        Assert.Less(finalHeight, initialHeight);
    }

    [TearDown]
    public void Teardown()
    {
        Destroy(player);
    }
}