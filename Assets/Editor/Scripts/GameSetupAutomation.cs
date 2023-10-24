// GameSetupAutomation.cs
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSetupAutomation : MonoBehaviour
{
    [MenuItem("Game Setup/Initialize Game")]
    public static void InitializeGame()
    {
        // Check if InputActionAsset exists, create if not
        var inputActionAsset = AssetDatabase.LoadAssetAtPath<InputActionAsset>("Assets/InputActions.inputactions");
        if (inputActionAsset == null)
        {
            inputActionAsset = ScriptableObject.CreateInstance<InputActionAsset>();
            AssetDatabase.CreateAsset(inputActionAsset, "Assets/InputActions.inputactions");
            AssetDatabase.SaveAssets();
            Debug.Log("InputActionAsset created at Assets/InputActions.inputactions");
        }
        else
        {
            Debug.Log("InputActionAsset found at Assets/InputActions.inputactions");
        }

        // Create player GameObject if it doesn't exist
        var playerObject = GameObject.Find("Player");
        if (playerObject == null)
        {
            playerObject = new GameObject("Player");
            Debug.Log("Player GameObject created");
        }
        else
        {
            Debug.Log("Player GameObject found");
        }

        // Attach PlayerInputHandler script to player GameObject
        var playerInputHandler = playerObject.GetComponent<PlayerInputHandler>();
        if (playerInputHandler == null)
        {
            playerInputHandler = playerObject.AddComponent<PlayerInputHandler>();
            Debug.Log("PlayerInputHandler component added to Player GameObject");
        }
        else
        {
            Debug.Log("PlayerInputHandler component found on Player GameObject");
        }

        // Assign InputActionAsset to PlayerInputHandler script
        playerInputHandler.playerActions = inputActionAsset;
        Debug.Log("InputActionAsset assigned to PlayerInputHandler");
    }
}