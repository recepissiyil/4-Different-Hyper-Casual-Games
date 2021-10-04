using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotdog : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hotdog")
        {
            Destroy(this.gameObject);
            PlayerManagerTwo.instance.ObjectInstantiate(4);
        }
    }
}
