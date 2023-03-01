using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Colidiu Com o Player");
            collision.gameObject.GetComponent<LifeSystem>().LifeDecrease(damageAmount);
            collision.gameObject.GetComponent<PushBackOnDamage>().TakeDamage();
        }
    }
}
