using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // Reference to the PlayerController script
    [Tooltip("Reference to the PlayerController script")]
    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        bool crouch = Input.GetButtonDown("Crouch");  // Assume you have set up a Crouch button in the Input settings
        bool primaryAttack = Input.GetButtonDown("Fire1");
        bool secondaryAttack = Input.GetButtonDown("Fire2");
        bool block = Input.GetButtonDown("Block");  // Assume you have set up a Block button in the Input settings

        // Now pass these input values to your player's action handling scripts
        HandleInput(horizontal, vertical, jump, crouch, primaryAttack, secondaryAttack, block);
    }

    // Function to handle the input
    void HandleInput(float horizontal, float vertical, bool jump, bool crouch, bool primaryAttack, bool secondaryAttack, bool block)
    {
        // TODO: Implement the logic to handle the input

        // Pass the input to the PlayerController script
        playerController.Move(horizontal, vertical);
        if (jump)
        {
            playerController.Jump();
        }
        if (crouch)
        {
            playerController.Crouch();
        }
        if (primaryAttack)
        {
            playerController.PrimaryAttack();
        }
        if (secondaryAttack)
        {
            playerController.SecondaryAttack();
        }
        if (block)
        {
            playerController.Block();
        }
    }
}