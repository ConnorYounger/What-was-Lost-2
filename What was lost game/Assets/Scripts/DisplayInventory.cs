using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPage, inventorySlot;
    public InventoryObject inventory;
    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var newSlot = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, inventoryPage.transform);
            newSlot.transform.SetParent(inventoryPage.transform);

            newSlot.GetComponentsInChildren<Image>()[1].sprite = inventory.Container[i].item.itemImage;
            newSlot.GetComponentsInChildren<Image>()[1].preserveAspect = true;
            newSlot.GetComponentInChildren<TMP_Text>().text = inventory.Container[i].item.itemName;
            itemsDisplayed.Add(inventory.Container[i], newSlot);
        }
    }
   
    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentsInChildren<Image>()[1].sprite = inventory.Container[i].item.itemImage;
                itemsDisplayed[inventory.Container[i]].GetComponentsInChildren<Image>()[1].preserveAspect = true;
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TMP_Text>().text = inventory.Container[i].item.itemName;
            } else
            {
                var newSlot = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, inventoryPage.transform);
                newSlot.transform.SetParent(inventoryPage.transform);

                newSlot.GetComponentsInChildren<Image>()[1].sprite = inventory.Container[i].item.itemImage;
                newSlot.GetComponentsInChildren<Image>()[1].preserveAspect = true;
                newSlot.GetComponentInChildren<TMP_Text>().text = inventory.Container[i].item.itemName;
                itemsDisplayed.Add(inventory.Container[i], newSlot);
            }
        }
    }
}
