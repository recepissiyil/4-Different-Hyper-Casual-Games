using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerTwo : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public static UIManagerTwo instance;
    private void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(4);
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
