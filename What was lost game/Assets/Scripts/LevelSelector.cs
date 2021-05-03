using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [Header("Postcard Buttons")]
    public Button level1Btn;
    public Button level2Btn;
    public Button level3Btn;
    public Button level4Btn;
    public Button level5Btn;
    
    [Header("Levels Unlocked")]
    public int levelsUnlocked;
    
    [Header("Level Scenes to load")]
    public string level1Scene;
    public string level2Scene;
    public string level3Scene;
    public string level4Scene;
    public string level5Scene;

    private void Start()
    {
        UpdateDestinations();

        // Add onClick listeners to each of the postcard buttons that load the designated scene
        level1Btn.onClick.AddListener(delegate { LoadDestination(level1Scene); });
        level2Btn.onClick.AddListener(delegate { LoadDestination(level2Scene); });
        level3Btn.onClick.AddListener(delegate { LoadDestination(level3Scene); });
        level4Btn.onClick.AddListener(delegate { LoadDestination(level4Scene); });
        level5Btn.onClick.AddListener(delegate { LoadDestination(level5Scene); });
    }

    private void Update()
    {
        UpdateDestinations();
    }

    private void UpdateDestinations()
    {
        // Retrieve the number of levels unlocked from the player prefs
        levelsUnlocked = PlayerPrefs.GetInt("LevelUnlocked");
        
        // Set all extra postcard buttons to unclickable
        level3Btn.interactable = false;
        level4Btn.interactable = false;
        level5Btn.interactable = false;

        // Run a switch against the levels unlocked to make corresponding postcard button clickable
        switch (levelsUnlocked)
        {
            case 1:
                level3Btn.interactable = true;
                break;
            case 2:
                level3Btn.interactable = true;
                level4Btn.interactable = true;
                break;
            case 3:
                level3Btn.interactable = true;
                level4Btn.interactable = true;
                level5Btn.interactable = true;
                break;
        }

    }
    
    public void ResetPlayerPrefs()
    {
        level3Btn.interactable = false;
        level4Btn.interactable = false; 
        level5Btn.interactable = false;
        PlayerPrefs.DeleteAll();
    }

    private void LoadDestination(string sceneToLoad)
    {
        // Loads the scene based on string set in inspector
        SceneManager.LoadScene(sceneToLoad);
    }
}
