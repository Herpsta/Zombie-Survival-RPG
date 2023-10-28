// Required namespaces
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Singleton instance
    public static InputManager Instance { get; private set; }

    // Expose InputActionAsset in the inspector
    [Tooltip("Global Input Actions")]
    public InputActionAsset GlobalInputActions;

    // InputActionMap for player controls
    private InputActionMap playerControls;

    private void Awake()
    {
        // If there is no instance of InputManager, make this the instance
        if (Instance == null)
        {
            Instance = this;
            // Make sure this object persists across scene changes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }

        // TODO: Initialize player controls
        InitializePlayerControls();
    }

    private void OnEnable()
    {
        // Enable player controls when this script is enabled
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // Disable player controls when this script is disabled
        playerControls.Disable();
    }

    private void InitializePlayerControls()
    {
        // Find the "Player" action map within the GlobalInputActions
        playerControls = GlobalInputActions.FindActionMap("Player", true);

        // TODO: Add listeners for specific actions within the "Player" action map
        // Example: playerControls["Jump"].performed += ctx => Jump();
    }

    // TODO: Implement functions for specific actions
    // Example:
    // private void Jump()
    // {
    //     Debug.Log("Jump action performed");
    // }
}