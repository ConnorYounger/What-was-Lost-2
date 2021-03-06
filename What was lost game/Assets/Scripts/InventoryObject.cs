using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    // Add an item to the player inventory Scriptable Object
    public void AddItem(ItemObject _item)
    {
        Container.Add(new InventorySlot(_item));
    }

    // Remove an item to the player inventory Scriptable Object
    public void RemoveItem(int i)
    {
        Container.Remove(Container[i]);
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;

    public InventorySlot(ItemObject _item)
    {
        item = _item;
    }
}