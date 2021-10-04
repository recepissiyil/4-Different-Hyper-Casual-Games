using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cherry")
        {
            Destroy(this.gameObject);
            PlayerManagerTwo.instance.ObjectInstantiate(2);
        }
    }
}
