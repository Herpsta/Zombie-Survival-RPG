// PlayerInputHandler.cs
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Tooltip("Player Input Actions")]
    public InputActionAsset playerActions;

    private InputAction movement;
    private InputAction jump;
    private InputAction sprint;
    private InputAction crouch;
    private InputAction primaryAttack;
    private InputAction secondaryAttack;
    private InputAction block;
    private InputAction secondaryAttackHeld;  // New Input Action
    private InputAction powerAttackHeld;      // New Input Action
    private InputAction reload;               // New Input Action

    void Awake()
    {
        if (playerActions == null)
        {
            Debug.LogError("InputActionAsset is not assigned to PlayerInputHandler.");
            return;
        }

        movement = playerActions.FindAction("Movement");
        jump = playerActions.FindAction("Jump");
        sprint = playerActions.FindAction("Sprint");
        crouch = playerActions.FindAction("Crouch");
        primaryAttack = playerActions.FindAction("PrimaryAttack");
        secondaryAttack = playerActions.FindAction("SecondaryAttack");
        block = playerActions.FindAction("Block");
        secondaryAttackHeld = playerActions.FindAction("SecondaryAttackHeld");  // New Input Action
        powerAttackHeld = playerActions.FindAction("PowerAttackHeld");          // New Input Action
        reload = playerActions.FindAction("Reload");                            // New Input Action

        // Check if all actions are found
        InputAction[] actions = { movement, jump, sprint, crouch, primaryAttack, secondaryAttack, block, secondaryAttackHeld, powerAttackHeld, reload };  // Updated
        foreach (var action in actions)
        {
            if (action == null)
            {
                Debug.LogError("An action is not found.");
            }
        }
    }

    void OnEnable()
    {
        EnableAllActions();
    }

    void OnDisable()
    {
        DisableAllActions();
    }

    // Enable all actions
    private void EnableAllActions()
    {
        movement.Enable();
        jump.Enable();
        sprint.Enable();
        crouch.Enable();
        primaryAttack.Enable();
        secondaryAttack.Enable();
        block.Enable();
        secondaryAttackHeld.Enable();  // New Input Action
        powerAttackHeld.Enable();      // New Input Action
        reload.Enable();               // New Input Action
    }

    // Disable all actions
    private void DisableAllActions()
    {
        movement.Disable();
        jump.Disable();
        sprint.Disable();
        crouch.Disable();
        primaryAttack.Disable();
        secondaryAttack.Disable();
        block.Disable();
        secondaryAttackHeld.Disable();  // New Input Action
        powerAttackHeld.Disable();      // New Input Action
        reload.Disable();               // New Input Action
    }

    public Vector2 GetMoveInput()
    {
        return movement.ReadValue<Vector2>();
    }

    public bool GetJumpInputDown()
    {
        return jump.triggered;
    }

    public bool GetSprintInputDown()
    {
        return sprint.triggered;
    }

    public bool GetCrouchInputDown()
    {
        return crouch.triggered;
    }

    public bool GetPrimaryAttackInputDown()
    {
        return primaryAttack.triggered;
    }

    public bool GetSecondaryAttackInputDown()
    {
        return secondaryAttack.triggered;
    }

    public bool GetBlockInputDown()
    {
        return block.triggered;
    }

    // New Methods
    public bool GetSecondaryAttackInputHeldDown()
    {
        return secondaryAttackHeld.phase == InputActionPhase.Performed;
    }

    public bool GetPowerAttackInputHeldDown()
    {
        return powerAttackHeld.phase == InputActionPhase.Performed;
    }

    public bool GetReloadInputDown()
    {
        return reload.triggered;
    }
}
