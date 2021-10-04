using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Banana")
        {
            Destroy(this.gameObject);
            PlayerManagerTwo.instance.ObjectInstantiate(3);
        }

    }
}
