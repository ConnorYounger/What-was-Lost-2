using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public InventoryObject playerInventory;

    public int maxInventoryItems = 15;

    public TimeManager timeManager;

    public string levelSelectScene;

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
        EditorSceneManager.LoadScene("", 1);
    }
}
