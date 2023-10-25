// Create a new script named "PlayerActions.cs" and attach it to the Player GameObject.
using UnityEngine.ProBuilder;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public void HandlePrimaryAttack()
    {
        // Instantiate a new projectile and set its direction
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetDirection(transform.forward);
    }

    public void HandleSecondaryAttack()
    {
        // For demonstration, reusing the primary attack logic but you can modify this for a different attack
        HandlePrimaryAttack();
    }

    public void HandleBlock(bool isBlocking)
    {
        // Assume you have a Health component with a TakeDamage method
        Health playerHealth = GetComponent<Health>();
        playerHealth.isBlocking = isBlocking;  // Set blocking state in Health component
    }
}
