using UnityEngine;

public class CollectingArea : MonoBehaviour
{
    public static CollectingArea instance;
    public int oliveCount;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Olive")
        {
            UIManager.instance.OliveCount(++oliveCount / 2);
        }
    }

}
