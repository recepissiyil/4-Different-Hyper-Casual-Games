using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float timeValue;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject obj;
    #region Singleton

    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject player;
    private void FixedUpdate()
    {
        if (timeValue>0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        if (CollectingArea.instance.oliveCount==128&&timeValue>0)
        {
            UIManager.instance.WinBoard();
            UIManagerStarting.instance.buttons[0].interactable = true; 
        }
        if (timeValue<=0)
        {
            UIManager.instance.GameOver();
        }
        DisplayTime(timeValue);
    }
    private void Start()
    {
            for (int i = 0; i < 64; i++)
            {
                Instantiate(obj, new Vector3(Random.Range(-2f, 4f), 0f, Random.Range(-4.5f, 4f)), Quaternion.identity);
            }


    }
     void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
