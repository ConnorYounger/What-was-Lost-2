using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMerchant : MonoBehaviour
{
    public GameObject merchantPage;
    public TMP_Text currencyText;

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
    }

    private void UpdateDisplay()
    {
        currencyText.text = PlayerPrefs.GetInt("Currency").ToString();
    }
}
