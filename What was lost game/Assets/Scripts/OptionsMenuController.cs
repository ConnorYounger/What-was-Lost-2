using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Button audioBtn, displayBtn, controlsBtn, backBtn;
    public string mainScene;

    private void Start()
    {
        audioBtn.onClick.AddListener(OpenAudio);
        displayBtn.onClick.AddListener(OpenDisplay);
        controlsBtn.onClick.AddListener(OpenControls);
        backBtn.onClick.AddListener(GoBack);
    }

    private void GoBack()
    {
        SceneManager.LoadScene(mainScene);
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
