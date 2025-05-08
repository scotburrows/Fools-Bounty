using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerAbilities : MonoBehaviour
{

    public static int playerSlot = 0;
    public static int bullets = 3;
    public Transform target;
    public static Transform slot2;
    public static Transform slot3;
    public static Transform slot4;
    public Transform camera;
    public LayerMask treasure;
    public LayerMask monster;
    public LayerMask ammoShop;
    public LayerMask potionShop;

    public static int health = 100;
    public static int coins = 20;
    public ParticleSystem shootParticle;
    public AudioClip shootSound;
    AudioSource sound;
    public AudioClip hasteSound;
    int prev_health = health;
    public AudioClip dmgSound;
    int prev_coins = coins;
    public AudioClip moneySound;
    public AudioClip shopSound;
    public AudioClip pickupSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerSlot = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerSlot = 4;
        }

        if (prev_health > health)
        {
            sound.clip = dmgSound;
            sound.Play();
        }
        prev_health = health;
        if (prev_coins < coins)
        {
            sound.clip = moneySound;
            sound.Play();
        }
        else if (prev_coins > coins)
        {
            sound.clip = shopSound;
            sound.Play();
        }
        prev_coins = coins;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new(camera.transform.position, camera.transform.forward);
            RaycastHit hit;
            //Debug.DrawRay(camera.transform.position, camera.transform.forward * 50);

            if (playerSlot == 1 && bullets > 0)
            {
                Destroy(Instantiate(shootParticle.gameObject, camera.transform.position, camera.transform.rotation), 2.0f);
                sound.clip = shootSound;
                sound.Play();
                if (Physics.Raycast(ray, out hit, 25, monster))
                {
                    target = hit.transform;
                    //Debug.Log(target.GetComponent<Animator>());
                    if (target.parent.GetComponentInChildren<Animator>())
                    {
                        target.parent.GetComponentInChildren<Animator>().speed = 0.2f;
                    }
                    else
                    {
                        target.parent.parent.GetComponent<Animator>().speed = 0.2f;
                    }
                }
                bullets--;
            }
            else if (playerSlot == 2)
            {
                if (!slot2 && Physics.Raycast(ray, out hit, 4, treasure))
                {
                    slot2 = hit.transform;
                    slot2.GetComponent<Rigidbody>().useGravity = false;
                    slot2.Translate(new Vector3(0, -100, 0));

                    sound.clip = pickupSound;
                    sound.Play();
                }
                else if (slot2.GetComponent<Rigidbody>())
                {
                    slot2.position = camera.transform.position + camera.transform.forward * 3;
                    slot2.rotation = camera.rotation;
                    slot2.GetComponent<Rigidbody>().useGravity = true;
                    slot2 = null;
                }
                else
                {
                    PlayerMovement.haste = true;
                    sound.clip = hasteSound;
                    sound.Play();
                    slot2.Translate(new Vector3(0, 100, 0));
                    slot2 = null;
                }
            }
            else if (playerSlot == 3)
            {
                if (!slot3 && Physics.Raycast(ray, out hit, 4, treasure))
                {
                    slot3 = hit.transform;
                    slot3.GetComponent<Rigidbody>().useGravity = false;
                    slot3.Translate(new Vector3(0, -100, 0));

                    sound.clip = pickupSound;
                    sound.Play();
                }
                else if (slot3.GetComponent<Rigidbody>())
                {
                    slot3.position = camera.transform.position + camera.transform.forward * 3;
                    slot3.rotation = camera.rotation;
                    slot3.GetComponent<Rigidbody>().useGravity = true;
                    slot3 = null;
                }
                else
                {
                    PlayerMovement.haste = true;
                    sound.clip = hasteSound;
                    sound.Play();
                    slot3.Translate(new Vector3(0, 100, 0));
                    slot3 = null;
                }
            }
            else if (playerSlot == 4)
            {
                if (!slot4 && Physics.Raycast(ray, out hit, 4, treasure))
                {
                    slot4 = hit.transform;
                    slot4.GetComponent<Rigidbody>().useGravity = false;
                    slot4.Translate(new Vector3(0, -100, 0));

                    sound.clip = pickupSound;
                    sound.Play();
                }
                else if (slot4.GetComponent<Rigidbody>())
                {
                    slot4.position = camera.transform.position + camera.transform.forward * 3;
                    slot4.rotation = camera.rotation;
                    slot4.GetComponent<Rigidbody>().useGravity = true;
                    slot4 = null;
                }
                else
                {
                    PlayerMovement.haste = true;
                    sound.clip = hasteSound;
                    sound.Play();
                    slot4.Translate(new Vector3(0, 100, 0));
                    slot4 = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;
            //Debug.DrawRay(camera.transform.position, camera.transform.forward * 50);

            if (Physics.Raycast(ray, out hit, 5, ammoShop))
            {
                bullets += 1;
                coins -= 10;
            }
            if (Physics.Raycast(ray, out hit, 5, potionShop))
            {
                target = hit.transform;
                if (playerSlot <= 2)
                {
                    if (!slot2)
                    {
                        slot2 = target.parent.GetComponent<PotionStand>().potion1;
                        slot2.Translate(new Vector3(0, -100, 0));
                        coins -= 15;
                    }
                }
                else if (playerSlot == 3 || (slot2 && playerSlot <= 2))
                {
                    if (!slot3)
                    {
                        slot3 = target.parent.GetComponent<PotionStand>().potion2;
                        slot3.Translate(new Vector3(0, -100, 0));
                        coins -= 15;
                    }
                }
                else
                {
                    if (!slot4)
                    {
                        slot4 = target.parent.GetComponent<PotionStand>().potion3;
                        slot4.Translate(new Vector3(0, -100, 0));
                        coins -= 15;
                    }
                }
            }
        }
    }
}
