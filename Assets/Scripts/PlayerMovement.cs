using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Speed of the player")]
    public float speed = 5f;

    [Tooltip("Sprint speed of the player")]
    public float sprintSpeed = 10f;

    [Tooltip("Jump height of the player")]
    public float jumpHeight = 2f;

    [Tooltip("Crouch height of the player")]
    public float crouchHeight = 1f;

    [Tooltip("Stand height of the player")]
    public float standHeight = 2f;

    [Tooltip("Stamina of the player")]
    public float stamina = 100f;

    [Tooltip("Stamina depletion rate when sprinting")]
    public float staminaDepletionRate = 20f;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool isJumping = false;
    private bool isSprinting = false;

    // TODO: Add animator component for player animations
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        bool crouch = Input.GetButtonDown("Crouch");
        bool sprint = Input.GetButtonDown("Sprint");

        HandleMovement(horizontal, vertical, sprint);

        if (jump)
        {
            HandleJump();
        }

        HandleCrouch(crouch);
        ApplyGravity();
    }

    public void HandleMovement(float horizontal, float vertical, bool sprint)
    {
        moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection *= isSprinting ? sprintSpeed : speed;
        characterController.Move(moveDirection * Time.deltaTime);

        // TODO: Add animations for different player states
        animator.SetFloat("Speed", moveDirection.magnitude);
    }

    public void HandleJump()
    {
        if (characterController.isGrounded)
        {
            isJumping = true;
            moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);

            // TODO: Add jump animation
            animator.SetTrigger("Jump");
        }
    }

    public void HandleCrouch(bool isCrouching)
    {
        characterController.height = isCrouching ? crouchHeight : standHeight;

        // TODO: Add crouch animation
        animator.SetBool("Crouch", isCrouching);
    }

    public void HandleSprint(bool isSprinting)
    {
        if (stamina > 0)
        {
            this.isSprinting = isSprinting;
            if (isSprinting)
            {
                stamina -= staminaDepletionRate * Time.deltaTime;
            }
        }
        else
        {
            this.isSprinting = false;
        }
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }
        else if (isJumping)
        {
            isJumping = false;
        }
    }
}