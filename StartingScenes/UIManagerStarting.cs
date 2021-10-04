using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManagerStarting : MonoBehaviour
{
    public static UIManagerStarting instance;
    private void Awake()
    {
        instance = this;
    }
    public Button[] buttons;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    } 
    public void QuitButton()
    {
        Application.Quit();
    } 
    public void OpenScenes(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
