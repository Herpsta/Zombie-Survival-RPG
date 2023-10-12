using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingletonUIManager : MonoBehaviour
{
    public Text introText;
    public Button startButton;
    public Slider healthBar; // Add this line to reference the health bar UI element
    public static SingletonUIManager Instance;

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
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // This method will be called when the Start button is clicked
    public void StartTheGame()
    {
        // Load the Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }

    // Add this function to update the health bar
    public void UpdateHealthBar(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    public GameObject optionsPanel;  // Reference to the Options Panel GameObject

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

}
