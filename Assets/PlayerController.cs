using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] private float fallDeath = -7f;

    //SOUNDS
    public AudioClip jumpSFX;
    public AudioClip coinSFX;
    public AudioClip doubleJumpSFX;
    public AudioClip GameOverSFX;


    private bool doubleJump;
    Rigidbody2D rb;
    bool isGrounded;
    private AudioSource audioSource;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PhysicsMaterial2D playerMaterial = new PhysicsMaterial2D();
        playerMaterial.friction = 0f;
        playerMaterial.bounciness = 0f;
        GetComponent<Collider2D>().sharedMaterial = playerMaterial;
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        //Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //death check
        if (transform.position.y <= fallDeath) GameOver();
        if (transform.position.x <= -10f) GameOver();
        //Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); //jump, with jump force
                animator.SetBool("isJumping", true);
                PlaySFX(jumpSFX);

            }
            else if (doubleJump) //lets player double jump if not grounded
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce - 1); //less jump force on the 2nd jump
                doubleJump = true;
                PlaySFX(doubleJumpSFX);
            }


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
            PlaySFX(coinSFX);
            ScoreCounter.instance.coinCount++;//increment of one
        }
        if (other.gameObject.CompareTag("DoubleJump"))
        {
            ScoreCounter.instance.coinCount += 2;
            doubleJump = true;//enables double jump
            Destroy(other.gameObject);//removes powerup after collecting
            PlaySFX(coinSFX);

        }
    }
    public void GameOver()
    {
        if (ScoreCounter.isGameOver) return;
        ScoreCounter.isGameOver = true;
        rb.velocity = Vector2.zero; //stops player from moving
        StartCoroutine(ShowGameOver());
        PlaySFX(GameOverSFX);
    }
    IEnumerator ShowGameOver()
    {
        yield return new WaitForSecondsRealtime(0f); //waits for 1 second before showing game over screen
        GameOverScreen.instance.Show();
        Debug.Log("Trying to show game over screen");
        Debug.Log(GameOverScreen.instance);
    }


    private void PlaySFX(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
