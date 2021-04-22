using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Value Item", menuName = "Inventory System/Items/Value")]
public class ValueItem : ItemObject
{
    // How much the player can sell the item for
    public float itemValue;

    public void Awake()
    {
        type = ItemType.Value;
    }
}