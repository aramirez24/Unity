using System.Collections;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public Collider2D colliderSword;
    public float attackTime = 0.2f;
    public float attackCD = 0.5f;
    bool hasAttacked = false;
    public int attackDamage = 1;

    void Start()
    {
        colliderSword = GetComponentInChildren<Collider2D>();
        colliderSword.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasAttacked)
        {
            StartCoroutine(SwingSword());
        }
    }

    IEnumerator SwingSword()
    {
        hasAttacked = true;

        Vector3 startLocalPos = transform.localPosition;

        colliderSword.enabled = true;
        yield return new WaitForSeconds(attackTime);
        colliderSword.enabled = false;

        yield return new WaitForSeconds(attackCD);
        hasAttacked = false;
    }

    public void DamageTarget(int damage, EnemyStats enemy)
    {
        enemy.health -= damage;
    }
}
