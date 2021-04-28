using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseController : MonoBehaviour
{
    public GameObject optionCanvas;
    public Button resumeBtn, optionsBtn, levelSelectBtn, exitBtn;
    public bool gamePaused;
    
    public GameObject player;

    [SerializeField]
    private string mainMenuScene = "Home Menu";
    [SerializeField]
    private string levelSelectScene = "LevelSelect";

    private void Start()
    {
        gamePaused = false;
        
        player = GameObject.Find("Player");

        //optionCanvas = GameObject.Find("OptionsCanvas");

        resumeBtn.onClick.AddListener(ResumeGame);
        optionsBtn.onClick.AddListener(OpenOptionsMenu);
        levelSelectBtn.onClick.AddListener(LoadLevelSelect);
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

    private void LoadLevelSelect()
    {
        SceneManager.LoadScene(levelSelectScene);
    }

    private void ExitToMain()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
