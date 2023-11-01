using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputAssetCreator : MonoBehaviour
{
    [MenuItem("Assets/Create/Custom Input Asset")]
    public static void CreateInputAsset()
    {
        var inputActionAsset = ScriptableObject.CreateInstance<InputActionAsset>();

        var map = new InputActionMap("Gameplay");

        AddAction(map, "Movement", "<Keyboard>/w", "<Keyboard>/a", "<Keyboard>/s", "<Keyboard>/d", "<Keyboard>/upArrow", "<Keyboard>/leftArrow", "<Keyboard>/downArrow", "<Keyboard>/rightArrow");
        AddAction(map, "Jump", "<Keyboard>/space");
        AddAction(map, "Sprint", "<Keyboard>/leftShift");
        AddAction(map, "Crouch", "<Keyboard>/leftCtrl");
        AddAction(map, "PrimaryAttack", "<Mouse>/leftButton");
        AddAction(map, "SecondaryAttack", "<Mouse>/rightButton");
        AddAction(map, "Block", "<Mouse>/rightButton");
        AddAction(map, "PowerAttackHeld", "<Mouse>/leftButton;hold");
        AddAction(map, "SecondaryAttackHeld", "<Mouse>/rightButton;hold");
        AddAction(map, "Reload", "<Keyboard>/r");
        AddAction(map, "MeleeBash", "<Keyboard>/alt");

        inputActionAsset.AddActionMap(map);

        AssetDatabase.CreateAsset(inputActionAsset, "Assets/CustomInputAsset.inputactions");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = inputActionAsset;
    }

    private static void AddAction(InputActionMap map, string name, params string[] bindings)
    {
        var action = map.AddAction(name);
        foreach (var binding in bindings)
        {
            action.AddBinding(binding);
        }
    }
}
