using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float accel = 12f;
    [SerializeField] float decel = 16f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    Vector2 currentVelocity;

    Rigidbody2D rb;

    float moveX;
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
        moveX = Input.GetAxisRaw("Horizontal");
        //Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }

        animator.SetBool("isJumping", !isGrounded);

        //Flip sprite(looks left when going left, vice versa right) 
        if (moveX > 0)
            spriteRenderer.flipX = true; // facing right
        else if (moveX < 0)
            spriteRenderer.flipX = false;  // facing left
        Debug.Log(isGrounded);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isAttacking");
        }
    }
    void FixedUpdate()
    {

        Vector2 targetVelocity = new Vector2(moveX * maxSpeed, rb.velocity.y);

        float rate = (Mathf.Abs(moveX) > 0f) ? accel : decel;

        currentVelocity = Vector2.MoveTowards(
            new Vector2(rb.velocity.x, 0),
            new Vector2(targetVelocity.x, 0),
            rate * Time.fixedDeltaTime //smooth movement
        );

        rb.velocity = new Vector2(currentVelocity.x, rb.velocity.y);
        animator.SetBool("isWalking", moveX != 0 && isGrounded);




    }



}
