using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameUiController : MonoBehaviour
{
    [SerializeField] private Button goToMenuButton;
    [SerializeField] private Button restartGame; 
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private TextMeshProUGUI newHighScore;
    [SerializeField] private ParticleSystem _particle;
    private bool _particleAddScore = true;

    public int score;
    public int highScore;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }

    private void Start()
    {
        highScore = GlobalScore.Highscore;
        score = 0;
        UpdateScore(0);
        goToMenuButton.onClick.AddListener(()=>StartCoroutine(GoToMenu(0.12f)));
        restartGame.onClick.AddListener(Restart);
        settingsCanvas.SetActive(true);
    }

    public IEnumerator GoToMenu(float seconds)
    {
        yield return new WaitForSeconds(0.12f);
        SceneManager.LoadScene("Menu");
    }
    
    public void Restart()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoretext.text = "Score: " + score;

        if (highScore < score)
        {
            highScore = score;
            //Debug.Log(highScore);
            if (_particleAddScore)
            {
                Instantiate(_particle, new Vector3(newHighScore.rectTransform.position.x, newHighScore.rectTransform.position.y, newHighScore.rectTransform.position.z-0.1f ), _particle.transform.rotation, transform);
                var sq = DOTween.Sequence();
                sq.Append(newHighScore.transform.DOScale(1f, 1f));
                sq.Append(newHighScore.transform.DOScale(0f, 1f));
//                Debug.Log(GlobalScore.Highscore);
                _particleAddScore = false;
            }
            GlobalScore.Highscore = highScore;
        }
        
    }

    public void GameOver()
    {
        GlobalScore.Score = score;
        SceneManager.LoadScene("GameOver");
    }
}
