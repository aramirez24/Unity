using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 3;
    public GameObject[] deathEffect;
    public bool isDead = false;
    public float knockbackForce = 6f;
    public float knockbackDuration = 0.2f;
    public float knockbackUpForce = 2f;
    Rigidbody2D rb;

    bool isKnockbacked;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;

            Die();
        }
    }

    public void Die()
    {
        GameObject fxPrefab = deathEffect[Random.Range(0, deathEffect.Length)];
        GameObject fx = Instantiate(fxPrefab, transform.position, Quaternion.identity);

        Destroy(fx, 2f);
        Destroy(gameObject);
    }

    public void ApplyKnockback(Transform attacker)
    {
        if (isKnockbacked) return;

        StartCoroutine(KnockbackCoroutine(attacker));
    }

    IEnumerator KnockbackCoroutine(Transform attacker)
    {
        isKnockbacked = true;

        Vector2 direction = (transform.position - attacker.position).normalized;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        rb.linearVelocity = Vector2.zero; // corta el empuje
        isKnockbacked = false;
    }
}
