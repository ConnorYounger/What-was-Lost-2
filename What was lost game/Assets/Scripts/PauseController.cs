using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseController : MonoBehaviour
{
    public GameObject optionCanvas;
    public Button resumeBtn, optionsBtn, exitBtn;
    public bool gamePaused;
    
    private GameObject player;

    private string mainMenuScene;

    private void Start()
    {
        gamePaused = false;

        optionCanvas = GameObject.Find("OptionsCanvas");

        resumeBtn.onClick.AddListener(ResumeGame);
        optionsBtn.onClick.AddListener(OpenOptionsMenu);
        exitBtn.onClick.AddListener(ExitToMain);
    }

    private void Update()
    {
        if (!gamePaused)
        {
            if (Input.GetKeyDown("escape"))
            {
                Debug.Log("esacped");
                PauseGame();
            }
        }
        else if (gamePaused)
        {
            if (Input.GetKeyDown("escape"))
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        GetComponent<Canvas>().enabled = true;
        
        Time.timeScale = 0;

        player.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ResumeGame()
    {
        GetComponent<Canvas>().enabled = false;

        Time.timeScale = 1;

        player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OpenOptionsMenu()
    {
        GetComponent<Canvas>().enabled = false;
        optionCanvas.GetComponent<Canvas>().enabled = true;
    }

    private void ExitToMain()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
