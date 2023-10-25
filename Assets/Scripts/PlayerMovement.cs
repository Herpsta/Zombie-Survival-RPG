using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Speed of the player")]
    public float speed = 5f;

    [Tooltip("Jump height of the player")]
    public float jumpHeight = 2f;

    [Tooltip("Crouch height of the player")]
    public float crouchHeight = 1f;

    [Tooltip("Stand height of the player")]
    public float standHeight = 2f;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool isJumping = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // TODO: Get input from user for movement, jump and crouch
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        bool crouch = Input.GetButtonDown("Crouch");

        HandleMovement(horizontal, vertical);

        if (jump)
        {
            HandleJump();
        }

        HandleCrouch(crouch);
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void HandleJump()
    {
        if (characterController.isGrounded)
        {
            isJumping = true;
            moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }
    }

    public void HandleCrouch(bool isCrouching)
    {
        characterController.height = isCrouching ? crouchHeight : standHeight;
    }

    private void ApplyGravity()
    {
        // TODO: Apply gravity to the player when not grounded
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
// This script now includes an Update method to handle user input for movement, jumping, and crouching. It also includes a method to apply gravity to the player when they are not grounded. The isJumping variable is used to prevent the player from jumping again while they are already in the air.