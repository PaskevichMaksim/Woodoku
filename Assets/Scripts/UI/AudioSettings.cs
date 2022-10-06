using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private static readonly string VolumePref = "VolumePref";
    [SerializeField] private TextMeshProUGUI volumeText;
    private float volumefloat;
    [SerializeField] private AudioSource volumeAudio;
    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        volumefloat = PlayerPrefs.GetFloat(VolumePref);
        volumeAudio.volume = volumefloat;
        volumeText.text = volumeAudio.volume.ToString("0.0");
    }
}
