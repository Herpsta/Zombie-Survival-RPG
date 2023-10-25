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

    [Tooltip("Enable skipping of the splash screen")]
    public bool canSkip = false; // TODO: Add an option to skip the splash screen.

    [Tooltip("Type of transition to use")]
    public TransitionType transitionType = TransitionType.Fade; // TODO: Implement different types of transitions (e.g., slide, zoom).

    public enum TransitionType
    {
        Fade,
        Slide,
        Zoom
    }

    void Start()
    {
        logo.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(FadeInAndOut());
    }

    void Update()
    {
        if (canSkip && Input.anyKeyDown)
        {
            StopAllCoroutines();
            LoadNextScene();
        }
    }

    IEnumerator FadeInAndOut()
    {
        switch (transitionType)
        {
            case TransitionType.Fade:
                // Fade in
                logo.CrossFadeAlpha(1, fadeSpeed, false);
                yield return new WaitForSeconds(fadeSpeed + 1);

                // Fade out
                logo.CrossFadeAlpha(0, fadeSpeed, false);
                yield return new WaitForSeconds(fadeSpeed);
                break;

            case TransitionType.Slide:
                // TODO: Implement slide transition
                break;

            case TransitionType.Zoom:
                // TODO: Implement zoom transition
                break;
        }

        // Load next scene
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}