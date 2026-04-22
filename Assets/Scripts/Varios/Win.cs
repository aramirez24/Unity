using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("hasWin", true);

            SceneManager.LoadScene("Win");
        }
    }
}
