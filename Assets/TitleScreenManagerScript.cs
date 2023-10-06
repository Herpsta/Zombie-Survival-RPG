using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject optionsPanel;  // Reference to the Options Panel GameObject

    public void NewGame()
    {
        // SceneManager.LoadScene("CharacterCreation");
        Debug.Log("New clicked");
    }

    public void LoadGame()
    {
        Debug.Log("Load clicked");
    }

    public void OpenOptions()
    {
        // Load the OptionsScene
        SceneManager.LoadScene("OptionsScreen");
    }

    public void OpenCredits()
    {
        Debug.Log("Credits button clicked");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
