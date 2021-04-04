using UnityEngine;

[CreateAssetMenu(fileName = "Audio Settings", menuName = "Audio/Audio Settings")]

public class AudioSettings : ScriptableObject
{
    [Range(0, 100)] public int soundVolume;
    [Range(0, 100)] public int musicVolume;
}
