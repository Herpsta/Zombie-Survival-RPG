using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Tooltip("Speed of the projectile")]
    public float speed = 10f;

    [Tooltip("Damage inflicted by the projectile")]
    public int damage = 10;

    [Tooltip("Time after which the projectile will be destroyed")]
    public float expirationTime = 5f;

    [Tooltip("Type of the projectile")]
    public ProjectileType projectileType;

    private Vector3 direction;

    // Enum to define different types of projectiles
    public enum ProjectileType
    {
        Normal,
        Explosive,
        Piercing
    }

    void Start()
    {
        // TODO: Add logic for projectile expiration time.
        Destroy(gameObject, expirationTime);
    }

    void Update()
    {
        // The projectile should not move if its speed is zero
        if (speed != 0)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // The projectile should not deal damage if its damage is zero
            if (damage != 0)
            {
                // TODO: Implement different types of projectiles (e.g., explosive, piercing).
                switch (projectileType)
                {
                    case ProjectileType.Normal:
                        health.TakeDamage(damage);
                        break;
                    case ProjectileType.Explosive:
                        // Implement explosive damage logic here
                        break;
                    case ProjectileType.Piercing:
                        // Implement piercing damage logic here
                        break;
                }
            }

            // The projectile should destroy itself if it hits an object that has a Health component
            Destroy(gameObject);
        }
    }
}