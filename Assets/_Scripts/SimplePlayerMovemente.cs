using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;
    public float sprintMultiplier = 10f;

    [Header("Camera")]
    public Transform cameraTransform;
    public float lookSensitivity = 3f;

    private bool isSprinting;
    private float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Utilities.SetCursorLocked(true)
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Move();
        Look();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(horizontal, 0f, vertical);

        if (inputDir.sqrMagnitude > 1f)
        {
            inputDir.Normalize();
        }

        float currentSpedd = 0f;

        if(isSprinting)
        {
            currentSpedd = speed * sprintMultiplier;
        }
        else
        {
            currentSpedd = speed;
        }

        Vector3 move = transform.TransformDirection(inputDir) * Time.deltaTime;
        transform.position += move;
    }

    void Sprint()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        // Rotazione verticale della camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}
