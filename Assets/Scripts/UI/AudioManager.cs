using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string VolumePref = "VolumePref";

    private int firstPlayint;
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Scrollbar volumeScrollbar;
    private float volumefloat;
    [SerializeField] private AudioSource volumeAudio;

    private void Start()
    {
        firstPlayint = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayint == 0)
        {
            volumefloat = 0.5f;
            volumeScrollbar.value = volumefloat;
            PlayerPrefs.SetFloat(VolumePref, volumefloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            volumefloat = PlayerPrefs.GetFloat(VolumePref);
            volumeScrollbar.value = volumefloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(VolumePref, volumeScrollbar.value);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        volumeAudio.volume = volumeScrollbar.value;
        volumeText.text = volumeAudio.volume.ToString("0.0");
    }
}
