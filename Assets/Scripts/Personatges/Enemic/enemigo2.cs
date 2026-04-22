using UnityEngine;

public class enemigo2 : MonoBehaviour
{
    public int damage = 1;
    public GameObject[] deathEffect;
    public void Die()
    {
        GameObject fxPrefab = deathEffect[Random.Range(0, deathEffect.Length)];
        GameObject fx = Instantiate(fxPrefab, transform.position, Quaternion.identity);

        Destroy(fx, 2f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<ProvaQuadrat>().health -= damage;
            Die();
        }
    }
}
