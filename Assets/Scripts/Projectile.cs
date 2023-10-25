using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Tooltip("Speed of the projectile")]
    public float speed = 10f;  // TODO: Adjust speed as needed

    [Tooltip("Damage inflicted by the projectile")]
    public int damage = 10;  // TODO: Adjust damage as needed

    private Vector3 direction;

    void Update()
    {
        // TODO: Customize the projectile's behavior as needed
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;  // Normalize to ensure it's a unit vector
    }

    void OnTriggerEnter(Collider other)
    {
        // TODO: Customize what happens on collision based on your game's mechanics
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);  // Destroy the projectile on impact
    }
}
