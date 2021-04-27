using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneEnd : MonoBehaviour
{
    public VideoPlayer video;
    public string startingScene = "Concealed Cove";

    private bool checkForVideo;

    void Start()
    {
        Invoke("LoadNextLevel", 1);
    }

    void LoadNextLevel()
    {
        checkForVideo = true;
    }

    void Update()
    {
        if (checkForVideo && !video.isPlaying)
        {
            SceneManager.LoadScene(startingScene);
        }
    }
}
