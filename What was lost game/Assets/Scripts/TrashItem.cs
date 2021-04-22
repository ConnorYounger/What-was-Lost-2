using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trash Item", menuName = "Inventory System/Items/Trash")]
public class TrashItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.Trash;
    }
}