using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform player;
    float xRot;
    float yRot;
    float xMouse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * 12.5f;
        yRot += xMouse;
        xRot -= Input.GetAxisRaw("Mouse Y") * 12.5f;

        xRot = Mathf.Clamp(xRot, -90, 90);

        //transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        player.Rotate(Vector3.up * xMouse);

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            if (PlayerMovement.crouching) {
                transform.position += new Vector3(0, -0.2f, 0);
            }
            else {
                transform.position += new Vector3(0, 0.2f, 0);
            }
        }
    }
}
