using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    
    [SerializeField] private Scrollbar volumeScrollbar = null;
    [SerializeField] private TextMeshProUGUI volumeText = null;

    private void Start()
    {
        LoadValue();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeScrollbar.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValue();
    }

    private void LoadValue()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeScrollbar.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
