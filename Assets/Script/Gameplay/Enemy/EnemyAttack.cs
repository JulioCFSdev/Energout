using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public Animator _ani;
    [SerializeField] private Transform playerTransform;
    public bool _readyAttack = true;
    public bool isAttacking = false;
    private float attackRange = 3f;

    private void Update()
    {
        /*var rangeAttackX = Mathf.Abs(playerTransform.position.x) - Mathf.Abs(transform.position.x) <= 1F || Mathf.Abs(transform.position.x) - Mathf.Abs(playerTransform.position.x) >= 1f;
        var rangeAttackY = Mathf.Abs(playerTransform.position.y) - Mathf.Abs(transform.position.y) <= 0.5F || Mathf.Abs(transform.position.y) - Mathf.Abs(playerTransform.position.y) >= 0.5f;
        
        if (rangeAttackX && rangeAttackY)
        {
            _ani.SetTrigger("attack");
            StartCoroutine("CooldownAttack");
        }*/
        VerificaAtaque();
    }
    
    void VerificaAtaque() {
        Vector2 distancia = playerTransform.position - transform.position;
        if (distancia.magnitude <= attackRange && _readyAttack) {
            // Inimigo está dentro do alcance do ataque
            Vector2 direcao = distancia.normalized;
            // Verifica se há um obstáculo no caminho
            RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTransform.position);
            _ani.SetTrigger("attack");
            
            StartCoroutine("CooldownAttack");
        }
    }

    private IEnumerator CooldownAttack()
    {
        _readyAttack = false;
        yield return new WaitForSeconds(5f);
        _readyAttack = true;
    }
}
