using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public int combo = 0;
    [SerializeField] public float timeAttack;
    [SerializeField] public int countAttack;
    private Animator _ani;
    public bool isAttacking;
    public bool isComboFinish = true;
    public bool readyAttack = true;

    private void Start()
    {
        _ani = GetComponent<Animator>();
    }
    
    private void Update()
    {
        Combos();
    }
    
    public void StartCombo()
    {
        isAttacking = false;
        if (combo < countAttack)
        {
            combo++;
        }
    }

    public void FinishCombo()
    {
        print("Combo Finalizado");
        isAttacking = false;
        isComboFinish = true;
        combo = 0;
        StartCoroutine("CooldownAttack");
    }

    private IEnumerator CooldownAttack()
    {
        readyAttack = false;
        print("readyAttack : " + readyAttack);
        yield return new WaitForSeconds(timeAttack);
        readyAttack = true;
        print("readyAttack : " + readyAttack);
    }

    public void Combos()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAttacking && readyAttack)
        {
            print("FOI APERTADO O E e ENTREOU NA CONDIÇÃO");
            isAttacking = true;
            isComboFinish = false;
            _ani.SetTrigger("Attack"+combo);
            print("Attack"+combo);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Triggerou o ataque");
            other.gameObject.GetComponent<LifeSystem>().LifeDecrease(damage);
        }
    }
}
