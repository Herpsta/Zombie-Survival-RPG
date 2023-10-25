using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Tooltip("Projectile prefab to be instantiated when attacking")]
    public GameObject projectilePrefab;

    [Tooltip("Point from where the projectile will be spawned")]
    public Transform projectileSpawnPoint;

    [Tooltip("Speed at which the projectile will be fired")]
    public float projectileSpeed = 10f;

    // TODO: Add a reference to the Health component in the inspector if it's not added automatically
    [Tooltip("Reference to the Health component of the player")]
    public Health playerHealth;

    private void Start()
    {
        // Check if the Health component is attached to the player
        if (playerHealth == null)
        {
            playerHealth = GetComponent<Health>();
        }
    }

    public void HandlePrimaryAttack()
    {
        // Instantiate a new projectile and set its direction
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetDirection(transform.forward);

        // Add force to the projectile to move it
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("No Rigidbody component found on the projectile prefab.");
        }
    }

    public void HandleSecondaryAttack()
    {
        // TODO: Implement secondary attack logic
    }

    public void HandleBlock(bool isBlocking)
    {
        // Set blocking state in Health component
        playerHealth.isBlocking = isBlocking;
    }
}