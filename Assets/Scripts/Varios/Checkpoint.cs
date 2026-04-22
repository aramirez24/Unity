using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    ChangeScene canvas;
    Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ChangeScene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isActive", true);
            canvas.currentSpawnPoint = this.gameObject.transform;
        }
    }
}
