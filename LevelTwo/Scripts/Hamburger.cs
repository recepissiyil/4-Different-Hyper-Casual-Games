using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hamburger")
        {
            Destroy(this.gameObject);
            PlayerManagerTwo.instance.ObjectInstantiate(5);
        }
    }
}
