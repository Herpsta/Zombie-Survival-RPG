// Create a new script named "InputHandler.cs" and attach it to the Player GameObject.
using UnityEngine;

public class InputHandler : MonoBehaviour
{
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
    }
}
