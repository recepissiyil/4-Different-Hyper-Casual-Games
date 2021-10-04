using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManagerFour : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public static UIManagerFour instance;
    public TextMeshProUGUI scoreText;
    private void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ScoreOnBoard(int score)
    {
        scoreText.text = ("Score : "+score).ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(5);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void WinBoard()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

}
