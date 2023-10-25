using UnityEngine;
using UnityEngine.ProBuilder;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float speed;
    public float jumpHeight = 1.5f;
    public float crouchHeight = 0.5f;
    public float standHeight = 2f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    private PlayerInputHandler inputHandler;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isCrouching = false;

    void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        characterController = GetComponent<CharacterController>();
        if (inputHandler == null || characterController == null)
        {
            Debug.LogError("Required component(s) missing on GameObject.");
        }
        speed = baseSpeed;
    }

    void Update()
    {
        if (inputHandler == null || characterController == null) return;

        float horizontal = inputHandler.GetMoveInput().x;
        float vertical = inputHandler.GetMoveInput().y;

        if (inputHandler.GetSprintInputDown())
        {
            speed *= 2;  // Double the speed if sprinting
        }

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        if (characterController.isGrounded)
        {
            velocity.y = -2f;  // Reset velocity when grounded
            if (inputHandler.GetJumpInputDown())
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);  // Jumping logic
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);  // Apply gravity

        if (inputHandler.GetCrouchInputDown())
        {
            isCrouching = !isCrouching;  // Toggle crouching state
            characterController.height = isCrouching ? crouchHeight : standHeight;  // Adjust characterController height
        }

        if (inputHandler.GetPrimaryAttackInputDown())
        {
            // Primary Attack logic
            FireProjectile();
        }

        if (inputHandler.GetSecondaryAttackInputDown())
        {
            // Secondary Attack logic
            FireProjectile(true);
        }

        if (inputHandler.GetBlockInputDown())
        {
            // Block logic
            BlockAttack();
        }

        // Reset speed back to original value if not sprinting
        if (!inputHandler.GetSprintInputDown())
        {
            speed = baseSpeed;
        }
    }

    void FireProjectile(bool isSecondary = false)
    {
        // Instantiate a new projectile and set its direction
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetDirection(transform.forward);

        if (isSecondary)
        {
            // If it's a secondary attack, maybe the projectile is faster or more powerful
            projectile.GetComponent<Projectile>().speed *=
                            2;  // For instance, doubling the speed of the projectile for secondary attack
        }
    }

    void BlockAttack()
    {
        // Assuming you have some sort of Health component with a TakeDamage method,
        // and a boolean to check if blocking is active.
        Health playerHealth = GetComponent<Health>();
        bool isBlocking = true;  // You would set this based on game logic, e.g., a button press

        // Connect this method to wherever you process incoming damage, 
        // e.g., a OnCollisionEnter method on a collider.
        playerHealth.onTakeDamage += (damage) =>
        {
            if (isBlocking)
            {
                // Reduce or negate the damage
                damage = 0;  // Negate damage completely
            }

            // Apply the (possibly reduced) damage
            playerHealth.TakeDamage(damage);
        };

        // Play a blocking animation
        // Assuming you have an Animator component with a Block animation.
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Block");
    }
}
