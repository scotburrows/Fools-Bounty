using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    float moveSpeed = 10f;
    public static float stamina = 400;
    public static Boolean canSprint = true;
    public static Boolean crouching = false;

    float fallSpeed = -10f;
    Vector3 gravity;
    public LayerMask ground;
    public LayerMask water;
    Boolean onGround = false;
    Boolean inWater = false;
    int swim = 0;

    Boolean prev_inWater;
    public AudioClip waterSound;
    AudioSource sound;
    public AudioSource oceanSound;
    public AudioSource windSound;
    public LayerMask windVolume;
    public LayerMask forestVolume;
    public AudioSource forestSound;

    public static Boolean haste = false;
    public static float haste_time = 400f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1f, forestVolume))
        {
            oceanSound.volume -= 0.075f * Time.deltaTime;
            windSound.volume -= 0.15f * Time.deltaTime;
            forestSound.volume += 0.15f * Time.deltaTime;
        }
        else if (Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1f, windVolume))
        {
            oceanSound.volume -= 0.075f * Time.deltaTime;
            windSound.volume += 0.1f * Time.deltaTime;
            forestSound.volume -= 0.1f * Time.deltaTime;
        }
        else
        {
            oceanSound.volume += 0.075f * Time.deltaTime;
            windSound.volume -= 0.1f * Time.deltaTime;
            forestSound.volume -= 0.1f * Time.deltaTime;
        }
        oceanSound.volume = Math.Clamp(oceanSound.volume, 0f, 0.75f);
        windSound.volume = Math.Clamp(windSound.volume, 0f, 1f);
        forestSound.volume = Math.Clamp(forestSound.volume, 0f, 1f);

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
        else if (Input.GetKey(KeyCode.LeftShift) && canSprint && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) {
            moveSpeed = 15f;
            stamina -= 75 * Time.deltaTime;
        }
        else {
            moveSpeed = 10f;
            stamina += 100 * Time.deltaTime;
        }
        stamina = Mathf.Clamp(stamina, 0, 400);
        if (stamina <= 1) {
            canSprint = false;
        }
        else if (stamina >= 395 && !crouching) {
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
        inWater = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 0.4f, water);

        // Movement with WASD
        Vector3 movement = (Input.GetAxisRaw("Horizontal") * transform.right) + (Input.GetAxisRaw("Vertical") * transform.forward);
        characterController.Move(movement * Time.deltaTime * moveSpeed);

        // Ground check
        if (onGround && gravity.y < 0)
        {
            fallSpeed = -1f;
        }
        else if (inWater)
        {
            fallSpeed = 0;
            gravity.y = 0;
            if (UnityEngine.Random.Range(0f, 2f) >= 1.5f)
            {
                stamina--;
            }
            if (prev_inWater != inWater)
            {
                sound.clip = waterSound;
                sound.Play();
            }
            //characterController.Move(new Vector3(0, (float) Math.Sin(swim++ * 1f), 0) * 0.5f);
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
