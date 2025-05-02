using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    float moveSpeed = 10f;
    public static int stamina = 400;
    public Boolean canSprint = true;
    public static Boolean crouching = false;

    float fallSpeed = -10f;
    Vector3 gravity;
    public LayerMask ground;
    public LayerMask water;
    Boolean onGround = false;
    Boolean inWater = false;
    int swim = 0;

    public static Boolean haste = false;
    public static float haste_time = 400f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            haste = true;
        }
        // Haste ability
        if (haste)
        {
            moveSpeed = 25f;
            // stamina++;
            haste_time -= (400 / 12) * Time.deltaTime;
            if (haste_time <= 0) {
                haste = false;
                haste_time = 200f;
            }
        }
        // Sprinting & stamina management
        else if (Input.GetKey(KeyCode.LeftShift) && canSprint) {
            moveSpeed = 15f;
            stamina--;
        }
        else {
            moveSpeed = 10f;
            stamina++;
        }
        stamina = Mathf.Clamp(stamina, 0, 400);
        if (stamina <= 1) {
            canSprint = false;
        }
        else if (stamina >= 190 && !crouching) {
            canSprint = true;
        }

        // Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = !crouching;
        }
        if (crouching)
        {
            canSprint = false;
            moveSpeed = 5f;
        }

        onGround = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), 0.5f, ground);
        inWater = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 0.2f, water);

        // Movement with WASD
        Vector3 movement = (Input.GetAxisRaw("Horizontal") * transform.right) + (Input.GetAxisRaw("Vertical") * transform.forward);
        characterController.Move(movement * Time.deltaTime * moveSpeed);

        // Ground check
        if (onGround && gravity.y < 0) {
            fallSpeed = -1f;
        }
        else if (inWater) {
            fallSpeed = 0;
            gravity.y = 0;
            //characterController.Move(new Vector3(0, (float) Math.Sinh(swim++ * 0.01 * Time.deltaTime), 0) * 0.5f);
        }
        else {
            fallSpeed = -10f;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterController.Move(new Vector3(0.001f, 0, 0));
            if (onGround || inWater)
            {
                gravity.y = 10f;
                //characterController.Move(new Vector3(0, 10, 0));
            }
        }

        // Gravity
        gravity.y += fallSpeed * Time.deltaTime;
        characterController.Move(gravity * Time.deltaTime);

    }
}
