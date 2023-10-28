using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Base speed of the player")]
    public float baseSpeed = 5f;
    [Tooltip("Sprint speed of the player")]
    public float sprintSpeed = 10f;
    [Tooltip("Jump height of the player")]
    public float jumpHeight = 2f;
    [Tooltip("Crouch height of the player")]
    public float crouchHeight = 1f;
    [Tooltip("Stand height of the player")]
    public float standHeight = 2f;
    // TODO: Add a reference to the Health component in the inspector if it's not added automatically
    [Tooltip("Reference to the Health component of the player")]
    public Health playerHealth;
    [Tooltip("Stamina of the player")]
    public float stamina = 100f;
    [Tooltip("Stamina depletion rate when sprinting")]
    public float staminaDepletionRate = 20f;

    [Header("Attack Settings")]
    [Tooltip("Projectile prefab to be instantiated when attacking")]
    public GameObject projectilePrefab;
    [Tooltip("Point from where the projectile will be spawned")]
    public Transform projectileSpawnPoint;
    [Tooltip("Speed at which the projectile will be fired")]
    public float projectileSpeed = 10f;

    [Header("Block Settings")]
    [Tooltip("Block duration in seconds")]
    public float blockDuration = 2f;
    [Tooltip("Block cooldown in seconds")]
    public float blockCooldown = 5f;

    [Header("Weapon Settings")]
    [Tooltip("Reference to the current weapon")]
    public IWeapon currentWeapon;

    private enum State { Idle, Moving, Jumping, Crouching, Attacking, Blocking }
    private State state = State.Idle;

    private PlayerInputHandler inputHandler;
    private CharacterController characterController;
    private Animator animator;
    private Vector3 velocity;
    private float speed;
    private float lastBlockTime = -Mathf.Infinity;
    private Vector3 moveDirection;
    private bool isJumping = false;
    private bool isSprinting = false;

    void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (inputHandler == null || characterController == null)
        {
            Debug.LogError("Required component(s) missing on GameObject.");
        }
        speed = baseSpeed;

        // Check if the Health component is attached to the player
        if (playerHealth == null)
        {
            playerHealth = GetComponent<Health>();
            if (playerHealth == null)
            {
                Debug.LogError("No Health component found on the player.");
            }
        }
    }


    void Update()
    {
        if (inputHandler == null || characterController == null) return;

        switch (state)
        {
            case State.Idle:
            case State.Moving:
                Sprint();
                Move();
                Jump();
                Crouch();
                HandleAttacking();
                Block();
                break;
            case State.Jumping:
                Jump();
                break;
            case State.Crouching:
                Crouch();
                break;
            case State.Attacking:
                HandleAttacking();
                break;
            case State.Blocking:
                Block();
                break;
        }
        ApplyGravity();
    }

    private void Move()
    {
        if (state == State.Blocking) return;

        float horizontal = inputHandler.GetMoveInput().x;
        float vertical = inputHandler.GetMoveInput().y;

        if (inputHandler.GetSprintInputDown() && stamina > 0)
        {
            speed = sprintSpeed;
            stamina -= staminaDepletionRate * Time.deltaTime;
        }
        else
        {
            speed = baseSpeed;
        }

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        state = moveDirection != Vector3.zero ? State.Moving : State.Idle;
    }


    private void Jump()
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

    private void Crouch()
    {
        if (state == State.Blocking) return;

        if (inputHandler.GetCrouchInputDown())
        {
            characterController.height = characterController.height == standHeight ? crouchHeight : standHeight;
            state = characterController.height == crouchHeight ? State.Crouching : State.Idle;
        }
    }

    private void Sprint()
    {
        if (inputHandler.GetSprintInputDown() && stamina > 0)
        {
            speed = sprintSpeed;
            stamina -= staminaDepletionRate * Time.deltaTime;
        }
        else
        {
            speed = baseSpeed;
        }
    }

    private void HandleAttacking()
    {
        if (state == State.Blocking) return;

        if (inputHandler.GetPrimaryAttackInputDown())
        {
            currentWeapon.PrimaryAction();
            state = State.Attacking;
        }

        if (inputHandler.GetSecondaryAttackInputHeldDown())
        {
            currentWeapon.SecondaryAction();
            state = State.Attacking;
        }

        if (inputHandler.GetPowerAttackInputHeldDown())
        {
            currentWeapon.PowerAttack();
            state = State.Attacking;
        }
    }

    private void PrimaryAttack()
    {
        currentWeapon.PrimaryAction();
        state = State.Attacking;
    }

    private void SecondaryAttack()
    {
        currentWeapon.SecondaryAction();
        state = State.Attacking;
    }


    private void Block()
    {
        if (Time.time < lastBlockTime + blockCooldown) return;

        if (inputHandler.GetBlockInputDown())
        {
            currentWeapon.Block();
            state = State.Blocking;
            lastBlockTime = Time.time;
            Invoke("EndBlock", blockDuration);
        }
    }

    private void Reload()
    {
        if (inputHandler.GetReloadInputDown())
        {
            currentWeapon.Reload();
        }
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        else if (isJumping)
        {
            isJumping = false;
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

    private void GatherResource()
    {
        // Logic for gathering resources
    }

    private void ManageInventory()
    {
        // Logic for managing inventory
    }

    private void UpdateHealth()
    {
        // Logic for updating health
    }

    private void UpdateStamina()
    {
        // Logic for updating stamina
    }

    private void Eat()
    {
        // Logic for eating
    }

    private void Drink()
    {
        // Logic for drinking
    }

    private void CraftItem()
    {
        // Logic for crafting items
    }

    private void BuildStructure()
    {
        // Logic for building structures
    }

    private void PlaceObject()
    {
        // Logic for placing objects
    }

    private void Interact()
    {
        // Logic for interaction with environment or entities
    }

    private void UseTool()
    {
        // Logic for using tools
    }

    private void ChangeEquippedItem()
    {
        // Logic for changing the equipped item
    }

    private void SavePlayerData()
    {
        // Logic for saving player data
    }

    private void LoadPlayerData()
    {
        // Logic for loading player data
    }
}