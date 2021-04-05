using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDisplay : MonoBehaviour
{   
  /*  public Transform uISpawn;
    void Start()
    {

    }
    public void SpawnItem()
    {
        GameObject generator = GameObject.Find("ItemRandomiser");
        RGenerator genScript = generator.GetComponent<RGenerator>();
        GameObject foundItem = Instantiate(genScript.item.modelPrefab, uISpawn.position, uISpawn.rotation);
        Destroy(foundItem, 5);
    }*/
  //After some investigaation, it seems the best way to do this is create a render texture, aka a screenshot / gif of the object and display that.
}
