using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerAbilities : MonoBehaviour
{

    public static int playerSlot = 1;
    public Transform slot1;
    public Transform slot2;
    public Transform camera;
    public LayerMask treasure;
    public LayerMask monster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerSlot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerSlot = 2;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;
            //Debug.DrawRay(camera.transform.position, camera.transform.forward * 50);

            if (playerSlot == 2 && !slot2 && Physics.Raycast(ray, out hit, 4, treasure))
            {
                slot2 = hit.transform;
                slot2.GetComponent<Rigidbody>().useGravity = false;
                slot2.Translate(new Vector3(0, -100, 0));
            }
            else if (playerSlot == 2 && slot2) {
                slot2.position = camera.transform.position + camera.transform.forward * 3;
                slot2.rotation = camera.rotation;
                slot2.GetComponent<Rigidbody>().useGravity = true;
                slot2 = null;
            }

        }

    }
}
