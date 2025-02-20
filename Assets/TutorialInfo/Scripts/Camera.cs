using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform orient;
    float xRot;
    float yRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yRot += Input.GetAxisRaw("Mouse X") * Time.deltaTime * 750;
        xRot -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 750;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
    }
}
