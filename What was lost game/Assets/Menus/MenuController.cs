using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //button functionalities to alternate between scenes
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    public string gameScene;
    public string optionsScene;

    public void Start()
    {
        //GetComponent to add listeners to button clicks

        playButton = GameObject.Find("New Game Button").GetComponent<Button>();
        playButton.onClick.AddListener(PlayGame);

        optionsButton = GameObject.Find("Options Button").GetComponent<Button>();
        optionsButton.onClick.AddListener(Options);

        quitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    //scene managers for scene loading
    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Options()
    {
        SceneManager.LoadScene(optionsScene);
    }

    //Debug to test quit application function in console
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
