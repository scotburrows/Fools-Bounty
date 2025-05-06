using System;
using Unity.Mathematics;
using UnityEngine;

public class PlantMonster : MonoBehaviour
{

    bool spotted_player = false;
    int hit_timer = 200;
    public LayerMask targetLayer;
    public Transform attack1;
    public Transform attack2;
    public Transform target;
    Animator animatorReference;
    public int attackTimer1 = 100;
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
            if (Physics.CheckSphere(transform.position, 25, targetLayer)) {
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
                        attack1.Translate(Vector3.up * 0.015f);
                    }
                    else if (attackTimer2 > 0)
                    {
                        atTop = true;
                        if (!Physics.CheckSphere(attack1.transform.position, 1, targetLayer))
                        {
                            attackTimer2--;
                            attack1.Translate(Vector3.up * -0.03f);
                        }
                    }
                    else if (!Physics.CheckSphere(attack1.transform.position, 1, targetLayer))
                    {
                        attackTimer2 = 0;
                        attackTimer1 = 100;
                        setPos = false;
                        atTop = false;
                    }
                }

                if (attackTimer2 == 0)
                {
                    if (!setPos)
                    {
                        attack2.transform.position = new Vector3(target.transform.position.x, transform.position.y - 1.5f, target.transform.position.z);
                        setPos = true;
                    }
                    else if (attack1.transform.localPosition.y < 0 && !atTop)
                    {
                        attack2.Translate(Vector3.up * 0.015f);
                    }
                    else if (attackTimer1 > 0)
                    {
                        atTop = true;
                        if (!Physics.CheckSphere(attack2.transform.position, 1, targetLayer))
                        {
                            attackTimer1--;
                            attack2.Translate(Vector3.up * -0.03f);
                        }
                    }
                    else if (!Physics.CheckSphere(attack2.transform.position, 1, targetLayer))
                    {
                        attackTimer1 = 0;
                        attackTimer2 = 100;
                        setPos = false;
                        atTop = false;
                    }
                }
            }
            else
            {
                if (attack1.transform.position.y > -1.5f)
                {
                    attack1.Translate(Vector3.up * -0.03f);
                }
                if (attack2.transform.position.y > -1.5f)
                {
                    attack2.Translate(Vector3.up * -0.03f);
                }
            }
            if (Physics.CheckSphere(transform.position, 1, targetLayer) && UnityEngine.Random.Range(0f, 1f) > 0.5)
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
                hit_timer = 200;
            }
        }
    }
}
