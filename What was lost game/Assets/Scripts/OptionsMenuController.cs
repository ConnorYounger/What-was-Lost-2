using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Button audioBtn, displayBtn, controlsBtn, exitBtn;
    public Button backBtn1, backBtn2, backBtn3;
    public GameObject navigationPage, displayPage, audioPage, controlPage;
    
    [Header("Set this to the Pause canvas in each level")]
    public GameObject topCanvas;

    private void Start()
    {
        //topCanvas.SetActive(false);
        topCanvas.GetComponent<Canvas>().enabled = false;

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
        //topCanvas.SetActive(true);
        topCanvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        //gameObject.SetActive(false);
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
        navigationPage.SetActive(false);
        displayPage.SetActive(true);
    }

    private void OpenAudio()
    {
        navigationPage.SetActive(false);
        audioPage.SetActive(true);
    }
}
