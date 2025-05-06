using System;
using Unity.Mathematics;
using UnityEngine;

public class SkeletonMonster : MonoBehaviour
{

    bool spotted_player = false;
    int hit_timer = 200;
    public LayerMask targetLayer;
    public Transform target;
    Animator animatorReference;
    Vector3 gravity;
    public LayerMask ground;
    float fallSpeed = -10f;
    CharacterController characterController;
    float animatorSpeed = 0f;

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
            if ((Physics.CheckSphere(transform.position, 15, targetLayer) && !PlayerMovement.crouching) || (PlayerMovement.crouching && Physics.CheckSphere(transform.position, 12, targetLayer))) {
                spotted_player = true;
            }
            else if (!Physics.CheckSphere(transform.position, 25, targetLayer))
            {
                spotted_player = false;
            }

            if (spotted_player)
            {
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 7 * Time.deltaTime);
                characterController.Move((target.transform.position - transform.position).normalized * 10 * Time.deltaTime);
                //transform.rotation = target.rotation + initial_rotation;
                transform.rotation = Quaternion.LookRotation(target.position - transform.position);
                animatorSpeed += 0.6f * Time.deltaTime;
            }
            else
            {
                animatorSpeed -= 0.6f * Time.deltaTime;
            }
            if (Physics.CheckSphere(transform.position, 1, targetLayer) && UnityEngine.Random.Range(0f, 1f) > 0.5)
            {
                PlayerAbilities.health -= 1;
                animatorSpeed -= 0.6f * Time.deltaTime;
            }
            animatorSpeed = Mathf.Clamp(animatorSpeed, 0f, 1f);
            animatorReference.SetFloat("Speed", animatorSpeed);
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

        Boolean onGround = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), 0.1f, ground);

        if (onGround && gravity.y < 0)
        {
            //fallSpeed = -1f;
        }
        if (!characterController.isGrounded)
        {
            gravity.y += fallSpeed * Time.deltaTime;
            characterController.Move(gravity * Time.deltaTime);
        }
    }
}
