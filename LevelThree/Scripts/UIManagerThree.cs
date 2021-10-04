using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerThree : MonoBehaviour
{
    public GameObject finishPanel;
    public static UIManagerThree instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lastScoreText;

    private void Awake()
    {
        instance = this;
    }
    public void ScoreBoard(int score)
    {
        scoreText.text = ("Score : "+score).ToString();
        lastScoreText.text = ("Score : "+score).ToString();
    }
    public void Finish()
    {
        finishPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
        finishPanel.SetActive(false);
        Debug.Log(Time.timeScale);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
