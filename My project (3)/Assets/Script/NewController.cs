using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public bool CanMove = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (CanMove)
        {
    
            if (Input.GetKey(KeyCode.W))
            {
                movement += transform.forward * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement -= transform.forward * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement -= transform.right * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += transform.right * MoveSpeed;
            }

            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
        else{
            rb.linearVelocity = new(0,0,0);
        }
    }
}