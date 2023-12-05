using UnityEngine;

public class Cam1P : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -90.0f;
    private const float Y_ANGLE_MAX = 90.0f;

    public float sensitivityX = 2.0f; 
    public float sensitivityY = 2.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.rotation = rotation;
    }
}