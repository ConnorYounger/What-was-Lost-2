using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    public bool customLightRotation;

    public ParticleSystem[] Clouds;

    private Animator ocean;
    public Animation oceanAnimation;

    //Variables
    [Range(0, 24)] public float timeOfDay;
    public float minutesPerDay = 10;

    [Range(0, 24)] public int startingHour = 8;
    [Range(0, 24)] public int endingHour = 18;

    public float baseLightIntensity = 0.6f;
    public float lightIntensityMultiplier = 0.8f;

    private void Start()
    {
        SetCloudSpeed();

        ocean = GameObject.Find("Ocean").GetComponent<Animator>();

        if(ocean)
        {
            //oceanAnimation = ocean.gameObject.GetComponent<Animation>();
        }
    }

    private void Update()
    {
        if (preset == null)
            return;

        if (Application.isPlaying && timeOfDay < endingHour)
        {
            //(Replace with a reference to the game time)
            float timeMultiplier = 1440 /  minutesPerDay;

            timeOfDay += ((Time.deltaTime * timeMultiplier) / 60) / 60;
            //timeOfDay %= 24; //Modulus to ensure always between 0-24
            timeOfDay = Mathf.Clamp(timeOfDay, startingHour, endingHour);
            
            if(timeOfDay >= endingHour)
            {
                //timeOfDay = startingHour;
            }

            UpdateLighting(timeOfDay / 24);
        }
        else
        {
            UpdateLighting(timeOfDay / 24);
        }
    }

    void SetCloudSpeed()
    {
        // If there are clouds, then set the speed relative to minutes per day
        if (Clouds.Length > 0)
        {
            foreach (ParticleSystem cloud in Clouds)
            {
                cloud.playbackSpeed = 24 / minutesPerDay;
            }
        }
    }

    // Handles lighting (Includes sun rotation, intensity and skybox color)
    private void UpdateLighting(float timePercent)
    {
        // Set ambient and fog
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        // If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);

            directionalLight.intensity = baseLightIntensity + (Mathf.Sin(timePercent * 3) * lightIntensityMultiplier);

            if (customLightRotation)
            {
                directionalLight.transform.rotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 0, 0));
            }
            else
            {
                directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 45, 0));
            }
        }

        if (ocean)
        {
            ocean.speed = 24 / minutesPerDay;

            //ocean.Play("OceanColourChange", 0, 20);
            ocean.Play("OceanColourChange");

            if (oceanAnimation)
            {
                //oceanAnimation["OceanColourChange"].time = 20;
            }
        }

        // Set the skybox color according to the skybox color preset
        if (RenderSettings.skybox.HasProperty("_Tint"))
        {
            RenderSettings.skybox.SetColor("_Tint", preset.skyBoxColor.Evaluate(timePercent));
        }
        else if (RenderSettings.skybox.HasProperty("_SkyTint"))
        {
            RenderSettings.skybox.SetColor("_SkyTint", preset.skyBoxColor.Evaluate(timePercent));
        }
    }

    // Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        // Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        // Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
