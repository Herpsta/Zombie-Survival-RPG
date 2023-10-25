using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;  // TODO: Set this value as per your game's requirement
    private int currentHealth;
    public bool isBlocking = false;  // TODO: Control this value based on your game's mechanics

    // Define a delegate (if using non-generic pattern).
    public delegate void TakeDamageEventHandler(int damage);
    // Define an event based on the delegate (if using non-generic pattern).
    public event TakeDamageEventHandler onTakeDamage;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            // TODO: Adjust damage calculation based on your game's mechanics
            damage /= 2;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within valid range

        // Invoke the onTakeDamage event, if there are any subscribers
        if (onTakeDamage != null)
        {
            onTakeDamage(damage);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: Handle death, e.g., play animation, disable the entity, etc.
        Debug.Log(gameObject.name + " has died.");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
