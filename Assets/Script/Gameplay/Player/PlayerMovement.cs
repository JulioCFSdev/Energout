using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] public float moveSpeed = 5f;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector2 _movementDirection;
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _spRend;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spRend = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        /* Normalize o vetor de direção do movimento para garantir que o jogador
        se mova em uma velocidade consistente, independentemente do ângulo do movimento. */
        _movementDirection = new Vector2(_horizontalInput, _verticalInput).normalized;

        IsRunning(_movementDirection);
        if (_playerAttack.isComboFinish)
        {
            // Calcular a nova posição do player
            Vector2 newPosition = _rb.position + _movementDirection * moveSpeed * Time.deltaTime;

            // Mover o player usando MovePosition
            _rb.MovePosition(newPosition);    
        }
    }

    public void IsRunning(Vector2 direction)
    {
        Flip(direction);
        if (direction.x > 0)
        {
            _anim.SetBool("run", true);
        }
        else if (direction.x < 0)
        {
            _anim.SetBool("run", true);
        }
        else if(direction.x == 0 && direction.y != 0)
        {
            _anim.SetBool("run", true);
        }
        else
        {
            _anim.SetBool("run", false);
        }
    }

    public void Flip(Vector2 direction)
    {
        //CollisorR = transform.Find("ColliderRight");
        //CollisorL = transform.Find("ColliderLeft");
        if (direction.x > 0 && _spRend.flipX)
        {
            _spRend.flipX = false;
            //CollisorR.gameObject.SetActive(true);
            //CollisorL.gameObject.SetActive(false);
        }
        
        if (direction.x < 0 && !_spRend.flipX)
        {
            //CollisorR.gameObject.SetActive(false);
            //CollisorL.gameObject.SetActive(true);
            _spRend.flipX = true;
        }
    }
}
