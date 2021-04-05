using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Sound", menuName = "Audio/Audio Sound")]

public class AudioSound : ScriptableObject
{
    public AudioClip sound;
    [Range(0, 100)] public float playWeight = 50;
    public float playChance;
}
