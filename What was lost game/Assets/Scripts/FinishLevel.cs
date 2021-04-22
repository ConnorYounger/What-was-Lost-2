using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public InventoryObject playerInventory;

    public int maxInventoryItems = 15;

    public TimeManager timeManager;

    public string levelSelectScene;

    public GameObject endUI;

    private void Start()
    {
        if (GameObject.Find("TimeManager"))
        {
            timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
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
        endUI.SetActive(true);

        Time.timeScale = 0;
    }

    // Button level select thing
}
