using System;
using Unity.Mathematics;
using UnityEngine;

public class GhostMonster : MonoBehaviour
{

    bool spotted_player = false;
    int hit_timer = 200;
    public LayerMask targetLayer;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInChildren<Animator>().speed == 1)
        {
            if (Physics.CheckSphere(transform.position, 10, targetLayer)) {
                spotted_player = true;
            }
            else if (!Physics.CheckSphere(transform.position, 25, targetLayer))
            {
                spotted_player = false;
            }

            if (spotted_player)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
                //transform.rotation = target.rotation + initial_rotation;
            }
        }
        else
        {
            hit_timer--;
            if (hit_timer == 0)
            {
                GetComponentInChildren<Animator>().speed = 1;
                hit_timer = 200;
            }
        }
    }
}
