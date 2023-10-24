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

        // Check if all actions are found
        InputAction[] actions = { movement, jump, sprint, crouch, primaryAttack, secondaryAttack, block };
        foreach (var action in actions)
        {
            if (action == null)
            {
                Debug.LogError("Action not found: " + action.name);
            }
        }
    }

    void OnEnable()
    {
        movement.Enable();
        jump.Enable();
        sprint.Enable();
        crouch.Enable();
        primaryAttack.Enable();
        secondaryAttack.Enable();
        block.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        jump.Disable();
        sprint.Disable();
        crouch.Disable();
        primaryAttack.Disable();
        secondaryAttack.Disable();
        block.Disable();
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
}