using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public int combo = 0;
    private Animator _ani;
    public bool isAttacking;

    private void Start()
    {
        _ani = GetComponent<Animator>();
    }

    public void StartCombo()
    {
        isAttacking = false;
        if (combo < 1)
        {
            combo++;
        }
    }

    public void FinishCombo()
    {
        print("Combo Finalizado");
        isAttacking = false;
        combo = 0;
    }

    public void Combos()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
        {
            print("FOI APERTADO O E e ENTREOU NA CONDIÇÃO");
            isAttacking = true;
            _ani.SetTrigger("Attack"+combo);
            print("Attack"+combo);
        }
    }
    
    

    private void Update()
    {
        Combos();
    }
}
