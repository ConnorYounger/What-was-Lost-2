using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InvDisplayController : MonoBehaviour
{
    private Canvas inventoryInterface;
    public GameObject inventoryPage;
    private bool isDisplayed;
    private GameObject player;

    void Start()
    {
        inventoryInterface = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        isDisplayed = inventoryInterface.enabled;

        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Check if the Inventory screen is displayed or not and then open or close it on input
        if (!isDisplayed)
        {
            if (Input.GetKeyDown("i"))
            {
                inventoryInterface.enabled = true;
                isDisplayed = true;
                
                inventoryPage.GetComponent<DisplayInventory>().UpdateDisplay();

                Time.timeScale = 0;

                player.GetComponent<FirstPersonController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (isDisplayed)
        {
            if (Input.GetKeyDown("i") || Input.GetKeyDown("escape"))
            {
                inventoryInterface.enabled = false;
                isDisplayed = false;

                Time.timeScale = 1;

                player.GetComponent<FirstPersonController>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
