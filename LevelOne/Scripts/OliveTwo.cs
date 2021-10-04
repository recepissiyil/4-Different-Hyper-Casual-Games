using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveTwo : MonoBehaviour
{
    private Rigidbody oliveRigid;
    private bool startAction;
    private void Awake()
    {
        oliveRigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        StartCoroutine(StartAction());
    }
    private void OnCollisionEnter(Collision other)
    {
        if (startAction == true)
        {

            if (other.gameObject.tag == "Olive")
            {
                Destroy(this.gameObject);

                PlayerManagerTwo.instance.ObjectInstantiate(1);

            }

        }

    }
    private IEnumerator StartAction()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Action!!");
        startAction = true;
    }
}
