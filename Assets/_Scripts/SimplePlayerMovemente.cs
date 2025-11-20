using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;
    public float sprintMultiplier = 1.5f;

    [Header("Camera")]
    public Transform comeraTransform;
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
        Sprint()
        Move()
        Look()
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(horizontal, 0f, vertical);

        if (inputDir.sqrMagnitude > 1f)
        {
            inputDir.Normalize()
        }

        float currentSpedd = of;

        if(isSprinting)
        {
            currentSpedd = speed * sprintMultiplier;
        }
        else
        {
            currentSpedd = speed;
        }

        Vector3 move = transform.TransformDirection(inputDir) * Time.deltaTime;
        trasform.position += move;
    }

    void Sprint()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShoft);
    }

    void look()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.Rotate(Vector3.up = mosueX);
    }
}
