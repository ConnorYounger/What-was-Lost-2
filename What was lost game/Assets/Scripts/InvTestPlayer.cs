using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvTestPlayer : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
