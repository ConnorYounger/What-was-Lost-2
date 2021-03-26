using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvDisplayController : MonoBehaviour
{
    private Canvas inventoryInterface;
    public bool isDisplayed;

    void Start()
    {
        inventoryInterface = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        isDisplayed = inventoryInterface.enabled;
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
            }
        }
        else if (isDisplayed)
        {
            if (Input.GetKeyDown("i"))
            {
                inventoryInterface.enabled = false;
                isDisplayed = false;
            }
        }
    }
}
