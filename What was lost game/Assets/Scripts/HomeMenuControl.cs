using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenuControl : MonoBehaviour
{
    public Button playBtn, optionsBtn, exitBtn;
    public string playScene, optionsScene;
    public GameObject optionsCanvas;

    private void Start()
    {
        optionsCanvas.SetActive(false);

        playBtn.onClick.AddListener(PlayGame);
        optionsBtn.onClick.AddListener(OptionsMenu);
        exitBtn.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(playScene);
    }

    private void OptionsMenu()
    {
        optionsCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
