using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] public int maxLifePoints;
    [SerializeField] public int currentlifePoints;
    [SerializeField] public int resistePoints;

    private Animator _anim;
    private bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        currentlifePoints = maxLifePoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlifePoints <= 0 && !isDead)
        {
            StartCoroutine("DeadDestroy");
        }
    }

    private IEnumerator DeadDestroy()
    {
        gameObject.GetComponent<EnemyMovement>().canMove = false;
        print("MORRI");
        _anim.SetTrigger("death");
        isDead = true;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void LifeIncreace(int increace)
    {
        print("Aumentou a vida do " + gameObject.name + " em " + increace);
        currentlifePoints += increace;
    }

    public void LifeDecrease(int damage)
    {
        if (damage > resistePoints)
        {
            print("Diminuiu a vida do " + gameObject.name + " em " + damage);
            currentlifePoints -= damage - resistePoints;
            if (currentlifePoints != 0)
            {
                _anim.SetTrigger("GetHit");    
            }
        }
    }
}
