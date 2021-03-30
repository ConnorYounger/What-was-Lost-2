using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDisplay : MonoBehaviour
{   
    public Transform uISpawn;
    void Start()
    {

    }
    public void SpawnItem()
    {
        GameObject generator = GameObject.Find("ItemRandomiser");
        RGenerator genScript = generator.GetComponent<RGenerator>();
        GameObject foundItem = Instantiate(genScript.item.modelPrefab, uISpawn.position, uISpawn.rotation);
        Destroy(foundItem, 5);
    }
}
