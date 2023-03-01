using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;  // velocidade de movimento do inimigo
    [SerializeField] public float stoppingDistance = 2f;  // distância mínima em que o inimigo para de se mover
    [SerializeField] public Transform target;  // alvo do inimigo (o personagem principal)
    public bool canMove = true;
    public bool isDead = false;
    public Vector2 direction;
    private Animator _ani;
    private SpriteRenderer _spRend;
    public EnemyAttack EnemyAttack;

    private void Start()
    {
        _ani = GetComponent<Animator>();
        _spRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Verifica se o alvo está definido
        if (!target || isDead)
        {
            _ani.SetBool("run", false);
            canMove = false;
            return;
        }

        // Calcula a direção para o alvo
        direction = target.position - transform.position;

        // Verifica se o inimigo está perto o suficiente para parar de se mover
        if (direction.magnitude <= stoppingDistance)
        {
            _ani.SetBool("run", false);
            canMove = false;
            return;
        }
        canMove = true;

    }

    public void FixedUpdate()
    {
        Movement(direction);
    }

    public void Movement(Vector2 direc)
    {
        Flip(direc);
        if (canMove && !EnemyAttack.isAttacking)
        {
            _ani.SetBool("run", true);
            // Move o inimigo em direção ao alvo
            transform.Translate(direc.normalized * speed * Time.deltaTime);
            
        }
    }

    public void Flip(Vector2 direction)
    {
        if (direction.x > 0 && _spRend.flipX)
        {
            _spRend.flipX = false;
        }
        
        if (direction.x < 0 && !_spRend.flipX)
        {
            _spRend.flipX = true;
        }
    }
}
