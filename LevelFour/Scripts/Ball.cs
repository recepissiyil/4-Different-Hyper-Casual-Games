using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    private Vector3 startingPoint;
    public float speed;
    public int objCount;
    public List<GameObject> objects;
    private void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        StartingHit();
        startingPoint = transform.position;
    }
    private void FixedUpdate()
    {
        if (objects.Count == 0)
        {
            UIManagerFour.instance.WinBoard();
        }
    }

    private void StartingHit()
    {
        ballRb.velocity = Vector3.zero;
        transform.position = startingPoint-new Vector3(0f,0f,7.23f);
        ballRb.velocity = new Vector3(speed, 0f, speed);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="RightWall")
        {
            ballRb.velocity = new Vector3(-speed, 0f, ballRb.velocity.z);
        }
        else if (other.gameObject.tag=="LeftWall")
        {
            ballRb.velocity = new Vector3(speed, 0f, ballRb.velocity.z);

        }
        else if (other.gameObject.tag=="TopWall")
        {
            ballRb.velocity = new Vector3(ballRb.velocity.x, 0f, -speed);
        }

        else if (other.gameObject.tag=="BottomWall")
        {
            UIManagerFour.instance.GameOver();
        }
        else if (other.gameObject.tag=="Cherry")
        {
            AfterCollision();
            Destroy(other.gameObject);
            speed *= 2f;
            ballRb.velocity = new Vector3(speed, 0f, speed);

        }
        else if (other.gameObject.tag == "Banana")
        {
            Pad.instance.transform.localScale = new Vector3(8f,transform.localScale.y,transform.localScale.z);
            Destroy(other.gameObject);
            AfterCollision();
        }
        else if (other.gameObject.tag == "Hamburger")
        {
            Pad.instance.directionPad = Vector3.left;
            Destroy(other.gameObject);
            AfterCollision();
        }
        else if (other.gameObject.tag == "Watermelon")
        {
            this.gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
            Destroy(other.gameObject);
            AfterCollision();
        }
        else if (other.gameObject.tag == "Olive")
        {
            Destroy(other.gameObject);
            AfterCollision();
        }
        else if (other.gameObject.tag == "Hotdog")
        {
            Destroy(other.gameObject);
            AfterCollision();
        }
        else if (other.gameObject.tag == "Cheese")
        {
            Destroy(other.gameObject);
            AfterCollision();
        }
        else if (other.gameObject.tag == "Pad")
        {
           ballRb.velocity = new Vector3(ballRb.velocity.x, 0f, speed);
        }
    }
    private void AfterCollision()
    {
        objects.RemoveAt(0);
        objCount++;
        UIManagerFour.instance.ScoreOnBoard(objCount);
    }
}
