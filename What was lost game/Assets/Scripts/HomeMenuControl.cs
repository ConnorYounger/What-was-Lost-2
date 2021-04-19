using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenuControl : MonoBehaviour
{
    public Button playBtn, optionsBtn, exitBtn;
    public string playScene, optionsScene;

    private void Start()
    {
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
        SceneManager.LoadScene(optionsScene);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
