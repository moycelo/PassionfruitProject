using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    Rigidbody2D rb;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PhysicsMaterial2D playerMaterial = new PhysicsMaterial2D();
        playerMaterial.friction = 0f;
        playerMaterial.bounciness = 0f;
        GetComponent<Collider2D>().sharedMaterial = playerMaterial;

    }
    void Update()
    {
        //Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }

        animator.SetBool("isJumping", !isGrounded);
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isAttacking");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);//removes coin after collecting
            ScoreCounter.instance.coinCount++;//increment of one
        }
    }

    //Hello!
}
