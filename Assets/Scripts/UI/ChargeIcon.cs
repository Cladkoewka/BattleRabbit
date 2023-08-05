using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    public Image Background;
    public Image Foreground;
    public TMP_Text TimerText;

    public void StartCharge()
    {
        Foreground.enabled = true;
        TimerText.enabled = true;
    }

    public void StopCharge()
    {
        Foreground.enabled = false;
        TimerText.enabled = false;
    }

    public void UpdateCharge(float currentCharge, float maxCharge)
    {
        Foreground.fillAmount = 1 - (currentCharge/maxCharge);
        TimerText.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}
