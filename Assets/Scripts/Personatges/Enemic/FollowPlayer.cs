using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public bool foundPlayer = false;
    public bool dumbEnemy = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            foundPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foundPlayer = false;
        }
    }

    private void Update()
    {
        if (dumbEnemy)
            return;
        if (player.IsDestroyed())
            return;
        if (player.GetComponent<ProvaQuadrat>().isDead)
            return;
        FollowFunction();
    }

    public void FollowFunction()
    {
        if (foundPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3f * Time.deltaTime);
        }
    }
}
