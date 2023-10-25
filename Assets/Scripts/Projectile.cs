using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Tooltip("Speed of the projectile")]
    public float speed = 10f;

    [Tooltip("Damage inflicted by the projectile")]
    public int damage = 10;

    private Vector3 direction;

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
                health.TakeDamage(damage);
            }

            // The projectile should destroy itself if it hits an object that has a Health component
            Destroy(gameObject);
        }
    }
}