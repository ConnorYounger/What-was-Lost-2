using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public int beachunlocked; 
    public Button[] lvlButtons;
    // Start is called before the first frame update
    void Start()
    {
    // 
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > beachunlocked)
                    lvlButtons[i].interactable = false; 
        }
    }

   
}
