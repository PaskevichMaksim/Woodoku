using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button exitTutorialButton;
    [SerializeField] private GameObject tutorial;
    // Start is called before the first frame update
    private void Start()
    {
        
        tutorial.transform.localScale = Vector3.zero;
        tutorialButton.onClick.AddListener(ClickTutorial);
        exitTutorialButton.onClick.AddListener(ExitTutorial);
    }
    
    public void ClickTutorial()
{
    if (tutorial.transform.localScale == Vector3.zero)
    {
        tutorial.transform.DOScale(1f, 0.7f);
    }
}

public void ExitTutorial()
{
    if (tutorial.transform.localScale != Vector3.zero)
    {
        tutorial.transform.DOScale(0f, 0.7f);
    }
}
}
