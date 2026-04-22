using UnityEngine;

public class trampolin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "groundCheck")
        {
            animator.SetBool("hasJumped", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "groundCheck")
        {
            animator.SetBool("hasJumped", false);
        }
    }
}
