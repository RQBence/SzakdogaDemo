using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class Charachter_Controller : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed = 3f;
    public bool CanMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("karakter");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {

            Player.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                Player.GetComponent<Rigidbody>().linearVelocity = new Vector3(-MoveSpeed, 0, Player.GetComponent<Rigidbody>().linearVelocity.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Player.GetComponent<Rigidbody>().linearVelocity = new Vector3(MoveSpeed, 0, Player.GetComponent<Rigidbody>().linearVelocity.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player.GetComponent<Rigidbody>().linearVelocity = new Vector3(Player.GetComponent<Rigidbody>().linearVelocity.x, 0, -MoveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Player.GetComponent<Rigidbody>().linearVelocity = new Vector3(Player.GetComponent<Rigidbody>().linearVelocity.x, 0, MoveSpeed);
            }

        }


        
    }
}
