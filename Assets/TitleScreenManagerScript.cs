using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
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
        Debug.Log("Options button clicked");
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
