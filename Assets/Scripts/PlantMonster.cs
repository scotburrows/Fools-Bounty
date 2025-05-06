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
    int attackTimer1 = 0;
    int attackTimer2 = 750;
    bool setPos = false;

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
            if (Physics.CheckSphere(transform.position, 15, targetLayer)) {
                spotted_player = true;
            }
            else if (!Physics.CheckSphere(transform.position, 20, targetLayer))
            {
                spotted_player = false;
            }

            if (spotted_player)
            {
                if (attackTimer1 == 0)
                {
                    if (!setPos)
                    {
                        attack1.transform.position.Set(target.transform.position.x, transform.position.y - 1.5f, target.transform.position.z);
                        setPos = true;
                    }
                    if (attack1.transform.localPosition.y < 0)
                    {

                    }
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
