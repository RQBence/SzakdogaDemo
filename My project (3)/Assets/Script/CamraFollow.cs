using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    public Transform characterBody;
    public float mouseSensitivity = 100f;

    // A kamera forgatasanak szelsoertekei ules kozben
    public float maxSittingXRotation = 30f;
    public float minSittingXRotation = -30f;
    public float maxSittingYRotation = 45f; 
    public float minSittingYRotation = -45f; 

    private float xRotation = 0f;
    private float yRotation = 0f;
    private CharacterSitController sitController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        sitController = characterBody.GetComponent<CharacterSitController>(); //Osszekotes a CharacterSitController scriptel
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (sitController != null && sitController.isSitting)
        {
            // X tengelyen valo kamera mozgatas fixalasa ules kozben
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, minSittingXRotation, maxSittingXRotation);

            // Y tengelyen valo kamera mozgatas fixalasa ules kozben
            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, minSittingYRotation, maxSittingYRotation);
        }
        else
        {
            //Kamera mozgatas amikor a karakter nem ul
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation += mouseX;
        }

        // A kamera forgatasa
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        characterBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}