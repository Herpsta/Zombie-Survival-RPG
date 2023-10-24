#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Zombie Survival/Setup Player Character")]
#endif
    public static void SetupPlayerCharacter()
    {
        // Create the PlayerCharacter prefab
        GameObject playerCharacter = new GameObject("PlayerCharacter");

        // Create Male and Female model game objects
        GameObject maleModel = new GameObject("MaleModel");
        maleModel.transform.SetParent(playerCharacter.transform);
        
        GameObject femaleModel = new GameObject("FemaleModel");
        femaleModel.transform.SetParent(playerCharacter.transform);

        // Add Animator component
        Animator animator = playerCharacter.AddComponent<Animator>();
        animator.runtimeAnimatorController = AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>("Assets/PathToYourAnimatorController.controller");
        
        // Save as a prefab
        PrefabUtility.SaveAsPrefabAssetAndConnect(playerCharacter, "Assets/Prefabs/PlayerCharacter.prefab", InteractionMode.UserAction);
        
        // Optionally destroy the game object from the scene if you only want the prefab
        DestroyImmediate(playerCharacter);
    }
}