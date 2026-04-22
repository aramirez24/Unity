using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    
    ProvaQuadrat player;
    EnemyStats enemicSaltat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        player = GetComponentInParent<ProvaQuadrat>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.isGrounded = true;
        }
        else if (collision.gameObject.tag == "Jump")
        {
            player.salts = 0;
            player.rb.linearVelocityY = player.velocitatSalt;
            enemicSaltat = collision.GetComponentInParent<EnemyStats>();
            enemicSaltat.Die();
        }
        else if(collision.gameObject.tag == "trampolin")
        {
            player.salts = 0;
            player.rb.linearVelocityY = player.velocitatSalt * player.multiplicadorSalt;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.isGrounded = false;
        }
    }
}
