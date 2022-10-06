using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;


public class UIController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject tutorialCanvas;

    private int _highScore;


    private void Start()
    {
        _highScore = GlobalScore.Highscore;
        _highScoreText.text = "High score: " + _highScore;
        startButton.onClick.AddListener(() => StartCoroutine(ClickStart()));
        settingsCanvas.SetActive(true);
        tutorialCanvas.SetActive(true);

    }

    public IEnumerator ClickStart()
    {
        yield return new WaitForSeconds(0.12f);
        SceneManager.LoadScene("Game");
    } 
    
}
