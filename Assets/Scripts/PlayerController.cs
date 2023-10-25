using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // State variables
    private bool isRolling = false;
    private bool isAttacking = false;

    // Speed of the player
    [Tooltip("Speed of the player")]
    public float speed = 5f;

    // Animator
    private Animator animator;

    // Rigidbody
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleRolling();
        HandleAttacking();
    }

    void HandleMovement()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a new vector3 for movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the rigidbody
        rb.AddForce(movement * speed);

        // Update animator parameters
        animator.SetFloat("Speed", movement.magnitude);
    }

    void HandleRolling()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            isRolling = true;
            // Implement rolling logic here
            // TODO: Implement rolling logic

            // Update animator parameters
            animator.SetBool("IsRolling", isRolling);
        }
    }

    void HandleAttacking()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            // Implement attacking logic here
            // TODO: Implement attacking logic

            // Update animator parameters
            animator.SetBool("IsAttacking", isAttacking);
        }
    }
}