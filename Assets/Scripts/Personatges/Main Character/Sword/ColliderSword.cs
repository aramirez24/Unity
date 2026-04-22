using UnityEngine;

public class ColliderSword : MonoBehaviour
{
    public Espada espada;

    private void Start()
    {
        espada = GetComponentInParent<Espada>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            espada.DamageTarget(espada.attackDamage, collision.GetComponent<EnemyStats>());
            collision.GetComponent<EnemyStats>()?.ApplyKnockback(transform);
        }
    }
}
