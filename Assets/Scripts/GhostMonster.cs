using System;
using Unity.Mathematics;
using UnityEngine;

public class GhostMonster : MonoBehaviour
{

    bool spotted_player = false;
    int hit_timer = 200;
    public LayerMask targetLayer;
    public Transform target;
    Animator animatorReference;
    public int range = 60;
    CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorReference = GetComponentInChildren<Animator>();
        characterController = GetComponentInChildren<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animatorReference.speed == 1)
        {
            if ((Physics.CheckSphere(transform.position, range, targetLayer) && !PlayerMovement.crouching) || (PlayerMovement.crouching && Physics.CheckSphere(transform.position, 10, targetLayer))) {
                spotted_player = true;
            }
            else if (!Physics.CheckSphere(transform.position, range + 20, targetLayer))
            {
                spotted_player = false;
            }

            if (spotted_player)
            {
                //transform.position = Vector3.MoveTowards(transform.position, target.position, 6 * Time.deltaTime);
                characterController.Move((target.transform.position - transform.position).normalized * 6 * Time.deltaTime);
                //transform.rotation = target.rotation + initial_rotation;
                transform.rotation = Quaternion.LookRotation(target.position - transform.position);
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
