using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text introText;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartTheGame);
    }

    // Update is called once per frame
    void Update()
    {
        introText.text = "Welcome to the Zombie Apocalypse!";
    }

    // This method will be called when the Start button is clicked
    public void StartTheGame()
    {
        // Load the Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
