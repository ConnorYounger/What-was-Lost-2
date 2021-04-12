using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;  
    }

    public void nTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Move To next level
            SceneManager.LoadScene(nextSceneLoad);

            //Setting Int for Index
            if(nextSceneLoad > PlayerPrefs.GetInt("beachunlocked"))
            {
                PlayerPrefs.SetInt("beachunlocked", nextSceneLoad);
            }
        }
    }
}
