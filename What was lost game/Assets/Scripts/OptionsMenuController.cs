using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Button audioBtn, displayBtn, controlsBtn, backBtn, exitBtn;
    public string mainScene;

    private void Start()
    {
        audioBtn.onClick.AddListener(OpenAudio);
        displayBtn.onClick.AddListener(OpenDisplay);
        controlsBtn.onClick.AddListener(OpenControls);
        backBtn.onClick.AddListener(GoBack);
    }

    private void CloseOptions()
    {
        SceneManager.LoadScene(mainScene);
    }

    private void GoBack()
    {
    }

    private void OpenControls()
    {
        throw new NotImplementedException();
    }

    private void OpenDisplay()
    {
        throw new NotImplementedException();
    }

    private void OpenAudio()
    {
        throw new NotImplementedException();
    }
}
