using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    [Tooltip("The logo to be displayed on the splash screen")]
    public Image logo;

    [Tooltip("The speed of the fade in/out animation")]
    public float fadeSpeed = 1.0f;

    [Tooltip("The name of the scene to load after the splash screen")]
    public string nextSceneName = "TitleScreen";

    void Start()
    {
        logo.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        // Fade in
        logo.CrossFadeAlpha(1, fadeSpeed, false);
        yield return new WaitForSeconds(fadeSpeed + 1);

        // Fade out
        logo.CrossFadeAlpha(0, fadeSpeed, false);
        yield return new WaitForSeconds(fadeSpeed);

        // Load next scene
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}