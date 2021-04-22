using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Button audioBtn, displayBtn, controlsBtn, exitBtn;
    public Button backBtn1, backBtn2, backBtn3;
    public GameObject navigationPage, displayPage, audioPage, controlPage;
    public GameObject topCanvas;

    private void Start()
    {
        topCanvas.SetActive(false);

        navigationPage.SetActive(true);
        displayPage.SetActive(false);
        audioPage.SetActive(false);
        controlPage.SetActive(false);

        audioBtn.onClick.AddListener(OpenAudio);
        displayBtn.onClick.AddListener(OpenDisplay);
        controlsBtn.onClick.AddListener(OpenControls);
        backBtn1.onClick.AddListener(GoBack);
        backBtn2.onClick.AddListener(GoBack);
        backBtn3.onClick.AddListener(GoBack);
        exitBtn.onClick.AddListener(CloseOptions);
    }

    private void CloseOptions()
    {
        topCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    private void GoBack()
    {
        navigationPage.SetActive(true);
        displayPage.SetActive(false);
        audioPage.SetActive(false);
        controlPage.SetActive(false);
    }

    private void OpenControls()
    {
        navigationPage.SetActive(false);
        controlPage.SetActive(true);
    }

    private void OpenDisplay()
    {
        displayPage.SetActive(false);
        controlPage.SetActive(true);
    }

    private void OpenAudio()
    {
        audioPage.SetActive(false);
        controlPage.SetActive(true);
    }
}
