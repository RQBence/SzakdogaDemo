using UnityEngine;

public class CharacterSitController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 SitPlace;
    public Transform sitPosition;
    public float sitDistance = 2f;
    public bool isSitting = false;
    private CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Player = GameObject.Find("karakter");
    }

    void Update()
    {
        if (!isSitting && sitPosition != null && Vector3.Distance(transform.position, sitPosition.position) < sitDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SitOnChair();
            }
        }
        else if (isSitting && Input.GetKeyDown(KeyCode.E))
        {
            StandUp();
        }
    }

    void SitOnChair()
    {
        SitPlace = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        transform.position = sitPosition.position;
        transform.rotation = sitPosition.rotation;
        isSitting = true;
        if (characterController != null)
        {
            characterController.CanMove = false;
        }
    }

    void StandUp()
    {
        isSitting = false;
        if (characterController != null)
        {
            characterController.CanMove = true;
            transform.position =SitPlace;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            sitPosition = other.transform.Find("SitPosition");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            sitPosition = null;
        }
    }
}