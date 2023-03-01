using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBackOnDamage : MonoBehaviour
{
    public float walkDistance = 2.0f; // a distância para onde o personagem vai andar para trás
    public float walkSpeed = 5.0f; // a velocidade de movimento do personagem para trás
    public float walkTime = 0.5f; // o tempo total de movimento para trás do personagem
    public float walkDelay = 0.1f; // o tempo de espera para o movimento acontecer depois do dano

    private bool isWalkingBack = false;
    private Vector3 walkTarget;
    private float walkTimer = 0.0f;

    void Update()
    {
        if (isWalkingBack)
        {
            walkTimer += Time.deltaTime;
            float walkProgress = walkTimer / walkTime;
            transform.position = Vector3.Lerp(transform.position, walkTarget, walkProgress);

            if (walkTimer >= walkTime)
            {
                isWalkingBack = false;
                walkTimer = 0.0f;
            }
        }
    }

    public void TakeDamage()
    {
        if (!isWalkingBack)
        {
            isWalkingBack = true;
            walkTarget = transform.position - transform.right * walkDistance;
            walkTimer = 0.0f;
        }
    }
}
