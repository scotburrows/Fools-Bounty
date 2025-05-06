using System;
using Unity.Mathematics;
using UnityEngine;

public class PlantMonster : MonoBehaviour
{

    bool spotted_player = false;
    int hit_timer = 400;
    public LayerMask targetLayer;
    public Transform attack1;
    public Transform attack2;
    public Transform target;
    Animator animatorReference;
    public int attackTimer1 = 0;
    public int attackTimer2 = 100;
    public bool setPos = false;
    public bool atTop = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorReference = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animatorReference.speed == 1)
        {
            if ((Physics.CheckSphere(transform.position, 25, targetLayer) && !PlayerMovement.crouching) || (PlayerMovement.crouching && Physics.CheckSphere(transform.position, 15, targetLayer))) {
                spotted_player = true;
            }
            else if (!Physics.CheckSphere(transform.position, 25, targetLayer))
            {
                spotted_player = false;
            }

            if (spotted_player)
            {
                if (attackTimer1 > 0 && attackTimer2 > 0)
                {
                    attackTimer1--;
                }
                if (attackTimer1 == 0)
                {
                    if (!setPos)
                    {
                        attack1.transform.position = new Vector3(target.transform.position.x, transform.position.y - 1.5f, target.transform.position.z);
                        setPos = true;
                    }
                    else if (attack1.transform.localPosition.y < 0 && !atTop)
                    {
                        attack1.Translate(Vector3.up * 2.5f * Time.deltaTime);
                    }
                    else if (attackTimer2 > 1)
                    {
                        atTop = true;
                        if (!Physics.CheckSphere(attack1.transform.position, 2, targetLayer))
                        {
                            attackTimer2--;
                            attack1.Translate(Vector3.up * -5.5f * Time.deltaTime);
                        }
                    }
                    else
                    {
                        setPos = false;
                        atTop = false;
                        attackTimer2 = 0;
                        attackTimer1 = 100;
                    }
                }

                if (attackTimer2 == 0)
                {
                    //Debug.Log(setPos);
                    //Debug.Log(atTop);
                    if (!setPos)
                    {
                        attack2.transform.position = new Vector3(target.transform.position.x, transform.position.y - 1.5f, target.transform.position.z);
                        setPos = true;
                        //Debug.Log("c");
                    }
                    else if (attack2.transform.localPosition.y < 0 && !atTop)
                    {
                        attack2.Translate(Vector3.up * 2.5f * Time.deltaTime);
                    }
                    else if (attackTimer1 > 1)
                    {
                        atTop = true;
                        if (!Physics.CheckSphere(attack2.transform.position, 2, targetLayer))
                        {
                            attackTimer1--;
                            attack2.Translate(Vector3.up * -5.5f * Time.deltaTime);
                        }
                    }
                    else
                    {
                        setPos = false;
                        atTop = false;
                        attackTimer1 = 0;
                        attackTimer2 = 100;
                        //Transform placeholder = attack2;
                        //attack1 = attack2;
                        //attack2 = placeholder;
                        //Debug.Log("b");
                    }
                }
            }
            else
            {
                if (attack1.transform.localPosition.y > -1.5f)
                {
                    attack1.Translate(Vector3.up * -4 * Time.deltaTime);
                }
                if (attack2.transform.localPosition.y > -1.5f)
                {
                    attack2.Translate(Vector3.up * -4 * Time.deltaTime);
                }
            }
            if ((Physics.CheckSphere(attack1.position, 2, targetLayer) || Physics.CheckSphere(attack2.position, 2, targetLayer)) && UnityEngine.Random.Range(0f, 1f) > 0.9)
            {
                PlayerAbilities.health -= 1;
            }
            if (Physics.CheckSphere(transform.position + Vector3.up * 0.75f, 2, targetLayer) && UnityEngine.Random.Range(0f, 1f) > 0.5)
            {
                PlayerAbilities.health -= 1;
            }
        }
        else
        {
            hit_timer--;
            if (hit_timer == 0)
            {
                animatorReference.speed = 1;
                hit_timer = 400;
            }
        }
    }
}
