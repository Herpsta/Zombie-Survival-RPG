// Create a new script named "PlayerMovement.cs" and attach it to the Player GameObject.
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float crouchHeight = 1f;
    public float standHeight = 2f;

    private CharacterController characterController;
    private Vector3 moveDirection;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void HandleJump()
    {
        moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
    }

    public void HandleCrouch(bool isCrouching)
    {
        characterController.height = isCrouching ? crouchHeight : standHeight;
    }
}
