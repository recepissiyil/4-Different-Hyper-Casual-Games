using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _horizontalInputs;
    private float _verticalInputs;
    private Rigidbody playerRigid;
    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {    
        Movement();
    }
    private void Movement()
    {
        _horizontalInputs = Input.GetAxis("Horizontal");
        _verticalInputs = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(_horizontalInputs, 0f, _verticalInputs);
        if (movement==Vector3.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(-movement);
        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime);
        playerRigid.MovePosition(playerRigid.position + movement * _speed * Time.fixedDeltaTime);
        playerRigid.MoveRotation(targetRotation);

    }
}
