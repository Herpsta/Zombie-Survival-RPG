using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [Tooltip("Base speed of the player")]
    public float baseSpeed = 5f;
    [Tooltip("Jump height of the player")]
    public float jumpHeight = 1.5f;
    [Tooltip("Crouch height of the player")]
    public float crouchHeight = 0.5f;
    [Tooltip("Stand height of the player")]
    public float standHeight = 2f;
    [Tooltip("Projectile prefab to be instantiated when attacking")]
    public GameObject projectilePrefab;
    [Tooltip("Point from where the projectile will be spawned")]
    public Transform projectileSpawnPoint;
    [Tooltip("Block duration in seconds")]
    public float blockDuration = 2f; // Added block duration

    private PlayerInputHandler inputHandler;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isCrouching = false;
    private bool isBlocking = false; // Added blocking state
    private float speed;

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

        HandleMovement();
        HandleJumping();
        HandleCrouching();
        HandleAttacking();
        HandleBlocking();
    }

    private void HandleMovement()
    {
        if (isBlocking) return; // No movement while blocking

        float horizontal = inputHandler.GetMoveInput().x;
        float vertical = inputHandler.GetMoveInput().y;

        if (inputHandler.GetSprintInputDown())
        {
            speed *= 2;  // Double the speed if sprinting
        }

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Reset speed back to original value if not sprinting
        if (!inputHandler.GetSprintInputDown())
        {
            speed = baseSpeed;
        }
    }

    private void HandleJumping()
    {
        if (isBlocking) return; // No jumping while blocking

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
    }

    private void HandleCrouching()
    {
        if (isBlocking) return; // No crouching while blocking

        if (inputHandler.GetCrouchInputDown())
        {
            isCrouching = !isCrouching;  // Toggle crouching state
            characterController.height = isCrouching ? crouchHeight : standHeight;  // Adjust characterController height
        }
    }

    private void HandleAttacking()
    {
        if (isBlocking) return; // No attacking while blocking

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
    }

    private void HandleBlocking()
    {
        if (inputHandler.GetBlockInputDown())
        {
            // Block logic
            BlockAttack();
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
            projectile.GetComponent<Projectile>().speed *= 2;  // For instance, doubling the speed of the projectile for secondary attack
        }
    }

    void BlockAttack()
    {
        // Block logic
        isBlocking = true;
        Invoke("EndBlock", blockDuration); // End block after blockDuration seconds
    }

    void EndBlock()
    {
        isBlocking = false;
    }
}