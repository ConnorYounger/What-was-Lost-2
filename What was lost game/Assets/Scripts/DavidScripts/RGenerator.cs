﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGenerator : MonoBehaviour
{
    private int randomRare;
    public InventoryObject inventory;
    public ItemObject item;
    public List<ItemObject> storyItems = new List<ItemObject>();
    public List<ItemObject> junkItems = new List<ItemObject>();
    public List<ItemObject> valueItems = new List<ItemObject>();
    private int sCount, jCount, vCount;
    void Start()
    {
        ItemObject[] objs1 = Resources.LoadAll<ItemObject>("Inventory/KeyItems/");

        foreach (ItemObject i in objs1)
        {
            storyItems.Add(i);
        }
        ItemObject[] objs2 = Resources.LoadAll<ItemObject>("Inventory/TrashItems/");

        foreach (ItemObject i in objs2)
        {
            junkItems.Add(i);
        }
        ItemObject[] objs3 = Resources.LoadAll<ItemObject>("Inventory/ValueItems/");

        foreach (ItemObject i in objs3)
        {
            valueItems.Add(i);
        }
        print(storyItems.Count);
        print(junkItems.Count);
        print(valueItems.Count);
        sCount = storyItems.Count;
        jCount = junkItems.Count;
        vCount = valueItems.Count;


    }
    public void Collect() // Runs when an object is walked over
    {
        //Randomly decide rarity of found item: Rare: 0-10 10% Uncommon 11-40 30% Common 41-100 60%
        randomRare = (Random.Range(0, 100));
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
         }
        



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
        randomRare = (Random.Range(0, sCount));
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
        randomRare = (Random.Range(0, jCount));
        print(randomRare);
        var item = junkItems[randomRare];
        if (item)
        {
            inventory.AddItem(item);
        }
    }
    void uncommonItem()
    {
        /*score = score + 5;
        print("Uncommon Item Found!");
        foundAlert.text = "Uncommon Item Found!";
        Invoke("reset", 2);*/
        randomRare = (Random.Range(0, vCount));
        print(randomRare);
        var item = valueItems[randomRare];
        if (item)
        {
            inventory.AddItem(item);
        }


    }  

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
