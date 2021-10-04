using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public int destroyObjCount;
    public float timeValue;
    public TextMeshProUGUI timerText;
    public GameObject obj;
    private BackgroundTile[,] allTiles;
    public GameObject[] dots;
    public GameObject[,] allDots;
    public Vector2[] cherryPositions;
    public Vector2[] bananaPositions;
    public Vector2[] watermelonPositions;
    private void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();   
        
    }
    private void FixedUpdate()
    {
        UIManagerThree.instance.ScoreBoard(destroyObjCount/10*3);
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        if (timeValue <= 0)
        {
            UIManagerThree.instance.Finish();
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

    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 temPositions = new Vector3(i, j, 0);
                GameObject backgroundTile = Instantiate(obj, temPositions, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "(" + i + "," + j + ")";
                int dotTouse = UnityEngine.Random.Range(0, dots.Length);
                int maxIterations=0;
                while (MatchesAt(i, j, dots[dotTouse])&&maxIterations<100)
                {
                    dotTouse = UnityEngine.Random.Range(0, dots.Length);
                    maxIterations++;
                }
                
                maxIterations = 0;
                GameObject dot = Instantiate(dots[dotTouse], temPositions, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "(" + i + "," + j + ")";
                allDots[i, j] = dot;
            }
        }
        //NewMethod();
    }
    private bool MatchesAt(int column, int row, GameObject piece)
    {
        if (column > 1 && row > 1)
        {
            if (allDots[column-1,row].tag==piece.tag&& allDots[column - 2, row].tag == piece.tag)
            {
                return true;
            }
            if (allDots[column , row - 1].tag == piece.tag && allDots[column , row - 2].tag == piece.tag)
            {
                return true;
            }
            else if(column<=1||row<=1)
            {
                if (row>1)
                {
                    if (allDots[column,row-1].tag==piece.tag&& allDots[column, row - 2].tag == piece.tag)
                    {
                        return true;
                    }
                }
                if (column > 1)
                {
                    if (allDots[column - 1, row ].tag == piece.tag && allDots[column - 2, row ].tag == piece.tag)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
    private void DestroyMatchesAt(int column,int row)
    {
        if (allDots[column,row].GetComponent<Dot>().isMatched)
        {
            Destroy(allDots[column, row]);
            allDots[column, row] = null;
        }
    }
    public void DestroyMatches()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j]!=null)
                {
                    destroyObjCount++;
                    DestroyMatchesAt(i, j);
                }
            }
        }
        StartCoroutine(DecreaseRowCo());
    }
    private IEnumerator DecreaseRowCo()
    {
        int nullCount = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j]==null)
                {
                    nullCount++;
                }
                else if (nullCount>0)
                {
                    allDots[i, j].GetComponent<Dot>().row -= nullCount;
                    allDots[i, j] = null;
                }
            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(.4f);
        StartCoroutine(FillBoardCo());
    } 
    private void RefillBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j]==null)
                {
                    Vector2 tempPosition = new Vector2(i, j);
                    int dotToUse = UnityEngine.Random.Range(0, dots.Length);
                    GameObject piece = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                    allDots[i, j] = piece;
                }
            }
        }
    }
    private bool MatchesOnBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j]!=null)
                {
                    if (allDots[i,j].GetComponent<Dot>().isMatched )
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private IEnumerator FillBoardCo()
    {
        RefillBoard();
        yield return new WaitForSeconds(.5f);
        while (MatchesOnBoard())
        {
            yield return new WaitForSeconds(.5f);
            DestroyMatches();
        }
    }
    //private void NewMethod()
    //{
    //    for (int a = 0; a < cherryPositions.Length; a++)
    //    {
    //        GameObject cherry = Instantiate(prefabs[0], cherryPositions[a] - new Vector2(0f, 0.45f), Quaternion.identity);
    //        cherry.transform.parent = this.transform;
    //        allDots[(int)cherryPositions[a].x,(int)cherryPositions[a].y] = cherry;
    //        Debug.Log(cherry.transform.name);
    //    }
    //    for (int b = 0; b < bananaPositions.Length; b++)
    //    {
    //        GameObject banana = Instantiate(prefabs[1], bananaPositions[b], Quaternion.identity);
    //        banana.transform.parent = this.transform;
    //        allDots[(int)bananaPositions[b].x, (int)bananaPositions[b].y] = banana;
    //        Debug.Log(banana.name);
    //    }
    //    for (int c = 0; c < watermelonPositions.Length; c++)
    //    {
    //        GameObject watermelon = Instantiate(prefabs[2], watermelonPositions[c] - new Vector2(0f, 0.45f), Quaternion.identity);
    //        watermelon.transform.parent = this.transform;
    //        allDots[(int)watermelonPositions[c].x, (int)watermelonPositions[c].y] = watermelon;
    //        Debug.Log(watermelon.name);
    //    }
    //}
}
