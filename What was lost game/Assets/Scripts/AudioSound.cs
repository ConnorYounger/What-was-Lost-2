using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Sound", menuName = "Audio/Audio Sound")]

public class AudioSound : ScriptableObject
{
    public AudioClip sound;
    [Tooltip("Set this relative to other sounds in the group. eg: if this is set to 50 and the other sounds are set to 25, that means this sound is twice as likly to play than the other sounds")] [Range(0, 100)] public float playWeight = 50;
    [Tooltip("Chance this sound has of playing relative to the other sounds in the sound group")] public float playChance;
}
