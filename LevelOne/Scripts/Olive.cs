using UnityEngine;

public class Olive : MonoBehaviour
{
    private Rigidbody oliveRigid;
    private void Awake()
    {
        oliveRigid = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.tag == "CollectArea")
        {
            transform.position = new Vector3(Random.Range(2f, -1f), transform.position.y, Random.Range(-7.5f, -6f));
            oliveRigid.isKinematic = true;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;

        }

    }

}
