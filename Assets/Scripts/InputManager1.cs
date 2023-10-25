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
    }
}