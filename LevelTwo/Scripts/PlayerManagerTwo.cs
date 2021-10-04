using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManagerTwo : MonoBehaviour
{
    [SerializeField] private float timeValue;
    [SerializeField] TextMeshProUGUI timerText;
    public bool win;
    [SerializeField] GameObject[] objects;
    public static PlayerManagerTwo instance;
    [SerializeField] int[] objInsCounts;

    #region Singleton
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject player;
    private void FixedUpdate()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        if (timeValue > 0&& win)
        {
            UIManagerTwo.instance.WinBoard();
        }
        if (timeValue <= 0)
        {
            UIManagerTwo.instance.GameOver();
        }
        DisplayTime(timeValue);
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Start()
    {
        for (int i = 0; i < 32; i++)
        {
            objInsCounts[0]++;
            Instantiate(objects[0], new Vector3(UnityEngine.Random.Range(-3f, 3f), 0.1f, UnityEngine.Random.Range(-8f, 2.28f)), Quaternion.identity);
        }
    }
    public void ObjectInstantiate(int objCount)
    {
        if (objCount == 1)
        {
            objInsCounts[1]++;
            if (objInsCounts[1] <= 32 && objInsCounts[1] % 2 == 0)
            {
                Instantiate(objects[objCount], new Vector3(UnityEngine.Random.Range(-2f, 4f), 0f, UnityEngine.Random.Range(-6f, 4f)), Quaternion.identity);
            }
        }
        else if (objCount == 2)
        {
            objInsCounts[2]++;
            if (objInsCounts[2] <= 16 && objInsCounts[2] % 2 == 0)
            {
                Instantiate(objects[objCount], new Vector3(UnityEngine.Random.Range(-1f, 3f), 0.1f, UnityEngine.Random.Range(-4f, 3f)), Quaternion.identity);
            }
        }
        else if (objCount == 3)
        {
            objInsCounts[3]++;
            if (objInsCounts[3] <= 8 && objInsCounts[3] % 2 == 0)
            {
                Instantiate(objects[objCount], new Vector3(UnityEngine.Random.Range(-2f, 4f), 0f, UnityEngine.Random.Range(-6f, 4f)), Quaternion.identity);
            }
        }
        else if (objCount == 4)
        {
            objInsCounts[4]++;
            if (objInsCounts[4] <= 4 && objInsCounts[4] % 2 == 0)
            {
                Instantiate(objects[objCount], new Vector3(UnityEngine.Random.Range(-2f, 4f), 0f, UnityEngine.Random.Range(-6f, 4f)), Quaternion.identity);
            }
        }
        else if (objCount == 5)
        {
            objInsCounts[5]++;
            if (objInsCounts[5] <= 1)
            {
                Instantiate(objects[objCount], new Vector3(UnityEngine.Random.Range(-2f, 4f), 0f, UnityEngine.Random.Range(-6f, 4f)), Quaternion.identity);
            }
        }
        else if (objCount == 6)
        {
            objInsCounts[6]++;

            if (objInsCounts[6] <= 1)
            {
                Instantiate(objects[objCount], new Vector3(UnityEngine.Random.Range(-2f, 2f), 0f, UnityEngine.Random.Range(-1f, 1f)), Quaternion.identity);
            }
            win = true;

        }
    }
}
