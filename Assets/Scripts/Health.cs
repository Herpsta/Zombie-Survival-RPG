using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Maximum health of the entity")]
    public int maxHealth = 100;  // Set this value as per your game's requirement
    private int currentHealth;
    [Tooltip("Is the entity currently blocking damage?")]
    public bool isBlocking = false;  // Control this value based on your game's mechanics

    // Define a delegate (if using non-generic pattern).
    public delegate void TakeDamageEventHandler(int damage);
    // Define an event based on the delegate (if using non-generic pattern).
    public event TakeDamageEventHandler onTakeDamage;

    // Define a delegate for death event
    public delegate void DeathEventHandler();
    // Define an event based on the delegate
    public event DeathEventHandler onDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            // Adjust damage calculation based on your game's mechanics
            damage /= 2;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within valid range

        // Invoke the onTakeDamage event, if there are any subscribers
        onTakeDamage?.Invoke(damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle death, e.g., play animation, disable the entity, etc.
        Debug.Log(gameObject.name + " has died.");

        // Invoke the onDeath event, if there are any subscribers
        onDeath?.Invoke();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Function to heal the entity
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within valid range
    }
}