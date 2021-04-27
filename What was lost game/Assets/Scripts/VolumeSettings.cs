using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer volumeMixer, musicMixer;

    public void SetVolume(float volume)
    {
        volumeMixer.SetFloat("volume", volume);
    }

    public void SetMusic(float volume)
    {
        musicMixer.SetFloat("music", volume);

    }
}
