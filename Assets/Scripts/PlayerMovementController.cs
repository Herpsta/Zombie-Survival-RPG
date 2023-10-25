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
    public float blockDuration = 2f;
    [Tooltip("Block cooldown in seconds")]
    public float blockCooldown = 5f; // Added block cooldown

    private PlayerInputHandler inputHandler;
    private CharacterController characterController;
    private Vector3 velocity;
    private float speed;
    private float lastBlockTime = -Mathf.Infinity; // Added last block time

    // TODO: Implement a state machine for better state management.
    private enum State { Idle, Moving, Jumping, Crouching, Attacking, Blocking }
    private State state = State.Idle;

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

        switch (state)
        {
            case State.Idle:
            case State.Moving:
                HandleMovement();
                HandleJumping();
                HandleCrouching();
                HandleAttacking();
                HandleBlocking();
                break;
            case State.Jumping:
                HandleJumping();
                break;
            case State.Crouching:
                HandleCrouching();
                break;
            case State.Attacking:
                HandleAttacking();
                break;
            case State.Blocking:
                HandleBlocking();
                break;
        }
    }

    private void HandleMovement()
    {
        if (state == State.Blocking) return;

        float horizontal = inputHandler.GetMoveInput().x;
        float vertical = inputHandler.GetMoveInput().y;

        if (inputHandler.GetSprintInputDown())
        {
            speed *= 2;
        }

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        if (!inputHandler.GetSprintInputDown())
        {
            speed = baseSpeed;
        }

        state = moveDirection != Vector3.zero ? State.Moving : State.Idle;
    }

    private void HandleJumping()
    {
        if (state == State.Blocking) return;

        if (characterController.isGrounded)
        {
            velocity.y = -2f;
            if (inputHandler.GetJumpInputDown())
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
                state = State.Jumping;
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void HandleCrouching()
    {
        if (state == State.Blocking) return;

        if (inputHandler.GetCrouchInputDown())
        {
            characterController.height = characterController.height == standHeight ? crouchHeight : standHeight;
            state = characterController.height == crouchHeight ? State.Crouching : State.Idle;
        }
    }

    private void HandleAttacking()
    {
        if (state == State.Blocking) return;

        if (inputHandler.GetPrimaryAttackInputDown())
        {
            FireProjectile();
            state = State.Attacking;
        }

        if (inputHandler.GetSecondaryAttackInputDown())
        {
            FireProjectile(true);
            state = State.Attacking;
        }
    }

    private void HandleBlocking()
    {
        if (Time.time < lastBlockTime + blockCooldown) return; // Added block cooldown

        if (inputHandler.GetBlockInputDown())
        {
            state = State.Blocking;
            lastBlockTime = Time.time;
            Invoke("EndBlock", blockDuration);
        }
    }

    void FireProjectile(bool isSecondary = false)
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetDirection(transform.forward);

        if (isSecondary)
        {
            projectile.GetComponent<Projectile>().speed *= 2;
        }
    }

    void EndBlock()
    {
        state = State.Idle;
    }
}