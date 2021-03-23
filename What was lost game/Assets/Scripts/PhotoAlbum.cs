using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotoAlbum : MonoBehaviour
{
    //public RectTransform parentPanel;
    public Sprite[] photos;
    public int imageNum;
    public GameObject prevPhoto, nextPhoto, photoMask;
    private string emptyText = "...";
    public string[] memoryCaptions = new string[4];
    public TMP_Text memoryText;
    private AudioSource photoChangeAudio;
    public bool[] photoFound;

    private void Start()
    {
        photoMask = GameObject.Find("Photo_Mask");
        photoFound = new bool[photos.Length];
        memoryText = GameObject.Find("Memory_Text").GetComponent<TMP_Text>();
        photoChangeAudio = GetComponent<AudioSource>();

        imageNum = 0;
        //memoryText.text = emptyText;

        UpdatePhoto();
    }

    // Change the photo display based on position in array & either display or hide a mask if the photo has been 'unlocked'
    public void UpdatePhoto()
    {
        gameObject.GetComponent<Image>().sprite = photos[imageNum];

        if (photoFound[imageNum])
        {
            photoMask.SetActive(false);
            memoryText.text = memoryCaptions[imageNum];
        }
        else if (!photoFound[imageNum])
        {
            photoMask.SetActive(true);
            memoryText.text = emptyText;
        }
    }

    // Change to the previous photo in array
    public void PrevPhoto()
    {
        imageNum = imageNum - 1;
        PlayPhotoChangeAudio();
        UpdatePhoto();
    }

    // Change to the next photo in array
    public void NextPhoto()
    {
        imageNum = imageNum + 1;
        PlayPhotoChangeAudio();
        UpdatePhoto();
    }

    // Play a sound effect when the photo is changed
    private void PlayPhotoChangeAudio()
    {
        photoChangeAudio.Play();
    }

    // Display or hide previous & next button based on position in photo array
    private void Update()
    {
        if (imageNum == 0)
        {
            prevPhoto.SetActive(false);
        }
        else
        {
            prevPhoto.SetActive(true);
        }

        if (imageNum == photos.Length - 1)
        {
            nextPhoto.SetActive(false);
        }
        else
        {
            nextPhoto.SetActive(true);
        }

    }
}