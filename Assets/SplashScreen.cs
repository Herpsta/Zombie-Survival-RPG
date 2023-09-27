using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Image logo;
    public float fadeSpeed = 1.0f;

    void Start()
    {
        logo.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
    }

    void fadeIn()
    {
        logo.CrossFadeAlpha(1, fadeSpeed, false);
        Invoke("fadeOut", fadeSpeed + 1);
    }

    void fadeOut()
    {
        logo.CrossFadeAlpha(0, fadeSpeed, false);
        Invoke("LoadNextScene", fadeSpeed);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
