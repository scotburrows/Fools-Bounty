using UnityEngine;

public class Camera : MonoBehaviour
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
        xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * 750;
        yRot += xMouse;
        xRot -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 750;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
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
