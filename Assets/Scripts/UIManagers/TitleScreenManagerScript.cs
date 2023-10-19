using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public Button exitButton; // Reference to the Exit Button

    private void Start()
    {
        // Add a listener to the Exit Button to call the ExitGame function when clicked
        exitButton.onClick.AddListener(ExitGame);
    }

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