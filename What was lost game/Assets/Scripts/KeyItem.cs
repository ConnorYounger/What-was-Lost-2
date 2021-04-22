using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Item", menuName = "Inventory System/Items/Key")]
public class KeyItem : ItemObject
{
    // Index associated with photo in album
    public int memoryNumber;

    public void Awake()
    {
        type = ItemType.Key;
    }
}