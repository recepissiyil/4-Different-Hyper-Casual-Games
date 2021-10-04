using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public static Pad instance;
    private Rigidbody padRb;
    public float speed;
    public Vector3 directionPad;
    private void Awake()
    {
        padRb = GetComponent<Rigidbody>();
        instance = this;
        directionPad = Vector3.right;
    }

    private void FixedUpdate()
    {
        PadControl();
    }
   public void PadControl()
    {
        float horizontalInputs = Input.GetAxis("Horizontal");
        padRb.velocity = directionPad * horizontalInputs * speed;
    }
}
