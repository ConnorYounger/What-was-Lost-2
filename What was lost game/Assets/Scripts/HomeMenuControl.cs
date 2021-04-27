using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenuControl : MonoBehaviour
{
    public Button playBtn, optionsBtn, exitBtn;
    public string playScene;
    public GameObject optionsCanvas;

    private void Start()
    {
        //optionsCanvas.SetActive(false);
        optionsCanvas.GetComponent<Canvas>().enabled = false;
        gameObject.GetComponent<Canvas>().enabled = true;

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
        optionsCanvas.GetComponent<Canvas>().enabled = true;
        gameObject.GetComponent<Canvas>().enabled = false;
        //optionsCanvas.SetActive(true);
        //gameObject.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
