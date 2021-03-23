using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private float timer;
    public float maxTime = 10.0f;
    public Image phil;

    void Update()
    {
        timer += Time.deltaTime;
        phil.fillAmount = (1.0f - (timer / 10.0f));
        if (timer > maxTime)
        {
            timer = 0.0f;
        }
    }
}
