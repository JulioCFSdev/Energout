using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector2 _movementDirection;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        print("Direção do Movimento" + _movementDirection);
        
        // Calcular a nova posição do player
        Vector2 newPosition = _rb.position + _movementDirection * moveSpeed * Time.deltaTime;

        // Mover o player usando MovePosition
        _rb.MovePosition(newPosition);
    }
}
