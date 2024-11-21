using UnityEngine;

public class CharacterSitController : MonoBehaviour
{
    public Transform sitPosition;
    public float sitDistance = 2f;
    public bool isSitting = false;
    private CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
            transform.position = new Vector3(-6f,0.25f,10f);
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