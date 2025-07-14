using UnityEngine;

public class FPS_Camera : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;


    public FPS_CameraFov cameraFov { get; private set; }
    public FPS_HeadBob headBob { get; private set; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraFov = GetComponent<FPS_CameraFov>();
        headBob = GetComponent<FPS_HeadBob>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
