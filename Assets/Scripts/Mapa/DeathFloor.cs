using Unity.VisualScripting;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    ChangeScene spawn;
    public Transform respawn;
    private void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ChangeScene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<ProvaQuadrat>().health -= 1;
            collision.transform.position = spawn.currentSpawnPoint.position;
            collision.GetComponent<ProvaQuadrat>().isGrounded = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
