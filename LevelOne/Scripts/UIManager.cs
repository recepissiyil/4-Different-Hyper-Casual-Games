using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public static UIManager instance;
    public TextMeshProUGUI oliveCountText;
    private void Awake()
    {
        instance = this;
    }
    public void OliveCount(int oliveCount)
    {
        oliveCountText.text = ("Score : "+oliveCount).ToString();
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        Debug.Log(Time.timeScale);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(3);
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
