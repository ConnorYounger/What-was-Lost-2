using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public InventoryObject playerInventory;

    public int maxInventoryItems = 15;

    public TimeManager timeManager;

    public GameObject endUI;
    public GameObject player;
    public GameObject endLevelCamera;

    private string levelSelectMenu = "Home Menu";

    private void Start()
    {
        if (GameObject.Find("TimeManager"))
        {
            timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        }
        else if (GameObject.Find("Tutorial Time Manager"))
        {
            timeManager = GameObject.Find("Tutorial Time Manager").GetComponent<TimeManager>();
        }

        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player");
        }

        if (GameObject.Find("DayOver"))
        {
            endUI = GameObject.Find("DayOver");
        }
    }

    private void Update()
    {
        if(playerInventory.Container.Count >= maxInventoryItems || (timeManager && timeManager.timeOfDay >= timeManager.endingHour))
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
        if (endLevelCamera)
        {
            endLevelCamera.SetActive(true);
        }

        endUI.SetActive(true);
        player.SetActive(false);

        //Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Travel()
    {
        SceneManager.LoadScene(levelSelectMenu);
    }
}
