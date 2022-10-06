using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private int finalScore;
    private void Start()
    {
        tryAgainButton.onClick.AddListener(()=>StartCoroutine(ClickTryAgain()));
        finalScore = GlobalScore.Score;
        //Debug.Log(finalScore);
       finalScoreText.text = "Score: " + finalScore;

    }
    
    public IEnumerator ClickTryAgain()
    {
        Mouse.QnttDestroy = 0;
        yield return new WaitForSeconds(0.001f);
        SceneManager.LoadScene("Game");        
    }
}
