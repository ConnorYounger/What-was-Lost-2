using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvTestPlayer : MonoBehaviour
{
    public InventoryObject inventory;
    private int speed = 3;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        var direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
