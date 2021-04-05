using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioSettings audioSettingsPrefab;
    public AudioSource musicAudioSource;
    public AudioSource[] soundSources;

    [Header("Ambiant Sounds")]
    public AudioGroup[] audioGroups;

    public float timeBetweenAmbiantSounds = 10;
    public float additionalTimeRandomness = 3;
    private float ambiantSoundTimer;

    private float totalSoundWeighting;

    private AudioSource audioSource;

    private List<float> otherWeights = new List<float>();
    private List<float> chances = new List<float>();

    private void Start()
    {
        timeBetweenAmbiantSounds += Random.Range(-additionalTimeRandomness, additionalTimeRandomness);

        if (gameObject.GetComponent<AudioSource>() && musicAudioSource)
        {
            audioSource = gameObject.GetComponent<AudioSource>();

            if (audioSettingsPrefab)
            {
                float soundVolume = audioSettingsPrefab.soundVolume;
                float musicVolume = audioSettingsPrefab.musicVolume;

                audioSource.volume = soundVolume / 100;
                musicAudioSource.volume = musicVolume / 100;

                foreach (AudioSource aSource in soundSources)
                {
                    aSource.volume = soundVolume / 100;
                }
            }
            else
            {
                Debug.LogError("Audio Manager is missing an Audio Settings prefab");
            }
        }
        else
        {
            Debug.LogError("Audio Manager is missing an Audio Source Component or Music Audio Source");
        }
    }

    void Update()
    {
        CalculateSoundChances();
        PlayRandomAmbiantSoundTimer();
    }

    private void PlayRandomAmbiantSoundTimer()
    {
        ambiantSoundTimer += Time.deltaTime;

        if(ambiantSoundTimer >= timeBetweenAmbiantSounds)
        {
            PlayRandomAmbiantSoundGroup();
            timeBetweenAmbiantSounds += Random.Range(-additionalTimeRandomness, additionalTimeRandomness);
            ambiantSoundTimer = 0;
        }
    }

    void PlayRandomAmbiantSoundGroup()
    {
        totalSoundWeighting = 0;

        foreach(AudioGroup group in audioGroups)
        {
            totalSoundWeighting += group.groupPlayWeight;
        }

        float randomNumber = Random.Range(1, totalSoundWeighting);
        float counter = 0;

        for(int i = 0; i < audioGroups.Length; i++)
        {
            if(randomNumber > counter && randomNumber < counter + audioGroups[i].groupPlayWeight)
            {
                PlayRandomAmbiantSound(audioGroups[i]);
            }

            counter += audioGroups[i].groupPlayWeight;
        }
    }

    void PlayRandomAmbiantSound(AudioGroup aGroup)
    {
        Debug.Log("audio group = " + aGroup);

        totalSoundWeighting = 0;

        foreach (AudioSound sound in aGroup.audioSounds)
        {
            totalSoundWeighting += sound.playWeight;
        }

        float randomNumber = Random.Range(1, totalSoundWeighting);
        float counter = 0;

        for (int i = 0; i < aGroup.audioSounds.Length; i++)
        {
            if (randomNumber > counter && randomNumber < counter + aGroup.audioSounds[i].playWeight)
            {
                PlayAmbiantSound(aGroup.audioSounds[i]);
            }

            counter += aGroup.audioSounds[i].playWeight;
        }
    }

    void PlayAmbiantSound(AudioSound aSound)
    {
        Debug.Log("Play " + aSound);

        if (audioSource && aSound.sound)
        {
            audioSource.clip = aSound.sound;
            audioSource.Play();
        }
    }

    // Calculate the sound play chances relative to the other sounds in the sound group
    private void CalculateSoundChances()
    {
        // These lists are use as local variables for calculating the sound chances
        otherWeights.Clear();
        chances.Clear();

        float groupPlayChance = 1;

        // Search through all of the audio groups in the array
        foreach (AudioGroup audioGroup in audioGroups)
        {
            // For each audio group, search through every sound in the audio group
            foreach (AudioSound sound in audioGroup.audioSounds)
            {
                // Reset the local variables for each sound
                otherWeights.Clear();
                chances.Clear();

                float playChance = 1;

                // Search through all of the sounds in the audio group that arn't the current sound and save it to the other weights list
                foreach (AudioSound otherSound in audioGroup.audioSounds)
                {
                    if (sound != otherSound)
                    {
                        otherWeights.Add(otherSound.playWeight);
                    }
                }

                // Next Calculate the chance of each sound relative to each other and add it to the chances list
                foreach (float otherWeight in otherWeights)
                {
                    float chance = sound.playWeight / otherWeight;
                    chances.Add(chance);
                }

                // Add all of the chances together
                foreach (float chance in chances)
                {
                    playChance = playChance * chance;
                }

                // Assign the chance to the sound scriptable object
                sound.playChance = playChance;
            }

            // Search for all of the audio groups that arn't the current group and their weights 
            foreach (AudioGroup otherGroup in audioGroups)
            {
                if (audioGroup != otherGroup)
                {
                    otherWeights.Add(otherGroup.groupPlayWeight);
                }
            }

            // Next Calculate the chance of each audio groups relative to each other and add it to the chances list
            foreach (float otherWeight in otherWeights)
            {
                float chance = audioGroup.groupPlayWeight / otherWeight;
                chances.Add(chance);
            }

            // Add all of the chances together
            foreach (float chance in chances)
            {
                groupPlayChance = groupPlayChance * chance;
            }

            // Assign the chance to the audio group scriptable object
            audioGroup.groupPlayChance = groupPlayChance;
        }
    }
}
