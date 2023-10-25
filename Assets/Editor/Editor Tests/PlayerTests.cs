using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerTests
{
    private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerActions playerActions;

    [SetUp]
    public void Setup()
    {
        // Instantiate a new player GameObject for testing
        player = new GameObject("Player");
        playerMovement = player.AddComponent<PlayerMovement>();
        playerActions = player.AddComponent<PlayerActions>();
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the player GameObject after each test
        Object.DestroyImmediate(player);
    }

    [Test]
    public void PlayerMovement_HandlesMovementCorrectly()
    {
        // Assume the player moves at speed 5 for 1 second in the positive x direction
        playerMovement.HandleMovement(1, 0);
        Assert.AreEqual(5, player.transform.position.x);
    }

    [Test]
    public void PlayerMovement_HandlesJumpCorrectly()
    {
        // Assume the player's y position changes correctly when jumping
        playerMovement.HandleJump();
        Assert.Greater(player.transform.position.y, 0);
    }

    [Test]
    public void PlayerMovement_HandlesCrouchCorrectly()
    {
        // Assume the player's height is 1 when crouching
        playerMovement.HandleCrouch(true);
        Assert.AreEqual(1, player.GetComponent<CharacterController>().height);
    }

    [Test]
    public void PlayerActions_HandlesPrimaryAttackCorrectly()
    {
        // Assume a projectile is instantiated when the primary attack is handled
        playerActions.HandlePrimaryAttack();
        Assert.AreEqual(1, Object.FindObjectsOfType<Projectile>().Length);
    }

    // ... Additional tests for secondary attack and block mechanics
}
