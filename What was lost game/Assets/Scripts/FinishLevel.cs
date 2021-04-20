using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public InventoryObject playerInventory;

    public TimeManager timeManager;

    public int maxInventoryItems = 15;

    private void Start()
    {
        if (GameObject.Find("TimeManager"))
        {
            timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
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

    }
}
