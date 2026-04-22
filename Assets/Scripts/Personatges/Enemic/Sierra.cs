using UnityEngine;

public class Sierra : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<ProvaQuadrat>().health -= 2;
        }
    }
}
