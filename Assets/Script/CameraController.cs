using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target; // Referência ao Transform do GameObject do player
    [SerializeField] public float distance = 10.0f; // Distância da câmera para o player
    [SerializeField] public float height = 5.0f; // Altura da câmera em relação ao player

    void LateUpdate()
    {
        // Verifica se a referência do Transform está definida
        if (target != null)
        {
            // Calcula a nova posição da câmera
            Vector3 newPosition = target.position - (Vector3.forward * distance) + (Vector3.up * height);

            // Move a câmera para a nova posição
            transform.position = newPosition;

            // Mantém a câmera na posição Z
            transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        }
    }
}
