﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGenerator : MonoBehaviour
{
    private int randomRare;
    public InventoryObject inventory;
    public ItemObject item;
    public List<ItemObject> storyItems = new List<ItemObject>();
    void Start()
    {
        ItemObject[] objs = Resources.LoadAll<ItemObject>("Inventory/KeyItems/");

        foreach (ItemObject i in objs)
        {
            storyItems.Add(i);
        }
    }
    public void Collect() // Runs when an object is walked over
    {
        //Randomly decide rarity of found item: Rare: 0-10 10% Uncommon 11-40 30% Common 41-100 60%
        /* randomRare = (Random.Range(0, 100));
         if (randomRare < 10)
         {
             valuableItem();
         }
         else if (randomRare > 41)
         {
             commonItem();
         }
         else
         {
             uncommonItem();
         } //Commented for testing - */
        valuableItem();



        // RaycastHit hit;
        // Vector3 groundLocation;
        // Debug.DrawLine(Vector3.zero, Vector3.up * 100);
        //  if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity))
        //  {
        //     groundLocation = hit.point;
        //     print(hit.collider.name);
        //     transform.position = groundLocation;

        // }

    }

    //Add different score amounts depending on rarity of found object and Alert player to rarity of found object
    void valuableItem()
    {
        /*score = score + 10;
        print("Rare Item Found!");
        foundAlert.text = "Rare Item Found!";
        Invoke("reset", 2);*/
        //  DAVID, had to comment this block, giving error
        randomRare = (Random.Range(1, 4));
        print(randomRare);
        var item = storyItems[randomRare];
        if (item)
        {
            inventory.AddItem(item);
        }
    }
    void commonItem()
    {
       /*score = score + 1;
       print("Common Item Found!");
       foundAlert.text = "Common Item Found!";
       Invoke("reset", 2);*/
    }
    void uncommonItem()
    {
        /*score = score + 5;
        print("Uncommon Item Found!");
        foundAlert.text = "Uncommon Item Found!";
        Invoke("reset", 2);*/
        

        
    }  

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}