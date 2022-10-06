using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitSettingsButton;
    [SerializeField] private GameObject settings;
    // Start is called before the first frame update
    private void Start()
    {
        settings.transform.localScale = Vector3.zero;
        settingsButton.onClick.AddListener(ClickSettings);
        exitSettingsButton.onClick.AddListener(ExitSettings);
    }
    
    public void ClickSettings()
{
    if (settings.transform.localScale == Vector3.zero)
    {
        settings.transform.DOScale(1f, 0.7f);
    }
}

public void ExitSettings()
{
    if (settings.transform.localScale != Vector3.zero)
    {
        settings.transform.DOScale(0f, 0.7f);
    }
}
}
