using UnityEngine;

public class ProvaQuadrat : MonoBehaviour
{
    //PROPIETATS DEL SCRIPT
    public float velocitat = 1f;
    public float forcaSalt = 1f;
    public float velocitatSalt = 1f;
    public float multiplicadorSalt;
    public SpriteRenderer sword;
    public GameObject colliderSword;
    public GameObject[] deathEffect;
    public int health = 3;
    public Transform currentCheckpoint;

    public float velocidad;

    [HideInInspector] public Rigidbody2D rb;
    public Transform groundCheck;
    SpriteRenderer sprite;
    Animator animator;

    public bool isGrounded = false;
    public bool isDead = false;
    public bool canMove = true;

    public int salts = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = rb.linearVelocityY;

        if (health <= 0 && !isDead)
        {
            health = 0;
            isDead = true;
            Die();
        }
        MouSetmana1();
    }

    void MouSetmana1()
    {
        if (!canMove)
            return;
        //Valor entre -1 i 1 per controlar moviment horitzontal
        float hInput = Input.GetAxis("Horizontal");

        //hInput: valor entre -1 i +1. 0 si no s'apreten tecles d'eix horitzontal
        float horizontalVelocity = hInput * velocitat;
        
        //Posem el valor que tingui, ho calcula el motor de físiques de unity
        float verticalVelocity = rb.linearVelocity.y;

        if (hInput > 0)
        {
            sprite.flipX = false;
            sword.transform.localPosition = new Vector3(0.9f, 0f, 0f);
            colliderSword.transform.localPosition = new Vector3(0.9f, 0f, 0f);
            sword.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else if (hInput < 0)
        {
            sprite.flipX = true;
            sword.transform.localPosition = new Vector3(-0.9f, 0f, 0f);
            colliderSword.transform.localPosition = new Vector3(-0.9f, 0f, 0f);
            sword.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (rb.linearVelocityY < 0)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

        if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("doubleJump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (salts == 0)
            {
                //Si apreta espai fem que vagi cap a dalt
                verticalVelocity = velocitatSalt;
                salts = 1;
            }
        }

        //Nova velocitat. Si no hi ha input serà (0, el que hi havia en y)
        rb.linearVelocity = new Vector2(horizontalVelocity, verticalVelocity);

        if (isGrounded == true)
        {
            salts = 0;
            animator.SetBool("isGrounded", true);
            animator.SetBool("doubleJump", false);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }

    void Die()
    {
        canMove = false;
        GameObject fxPrefab = deathEffect[Random.Range(0, deathEffect.Length)];
        GameObject fx = Instantiate(fxPrefab, transform.position, Quaternion.identity);

        Destroy(fx, 2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}
