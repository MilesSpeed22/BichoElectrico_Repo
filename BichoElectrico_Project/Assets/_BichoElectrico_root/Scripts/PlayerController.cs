using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isFacingRight;
    [SerializeField] int pushforce;
    float maxBatery;


    [Header("Shooting Config")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootCooldown = 5f;
    bool canShoot;
    
    


    Rigidbody2D PlayerRb;
    PlayerInput input;
    Vector2 moveInput;
    Animator anim;
    public bool dmgr;
    public bool sneaky;
    public int Batery;
    public Transform respawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        isGrounded = true;
        canShoot = true;
        sneaky = true;
    }

    public void dmg(Vector2 direction, int dmgc)
    {
        if (!dmgr)
        {
            AudioManager.instance.PlaySFX(1);
            dmgr = true;
            Batery -= dmgc;
            Vector2 push = new Vector2(transform.position.x - direction.x, 1);//.normalized;
            PlayerRb.AddForce(push * pushforce, ForceMode2D.Impulse);
            if (Batery <= 0)
                {
                AudioManager.instance.PlaySFX(2);
                anim.SetTrigger("Death");
            }
        }
    }

    public void fdmgr()
    {
        dmgr = false;
        PlayerRb.linearVelocity = Vector2.zero;
        anim.SetBool("Dmg", false);
    }

    void Start()
    {
        isFacingRight = true;
        maxBatery = Batery;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Sneakynt();
        AnimationManagement();

        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();

    }

    public void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (!dmgr)
        {
            PlayerRb.linearVelocity = new Vector2(moveInput.x * speed, PlayerRb.linearVelocity.y);
        }
    }

    void Jump()
    {
        AudioManager.instance.PlaySFX(0);
        PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        
    }

    public void Sneakynt()
    {
        if (maxBatery > Batery)
        {
            sneaky = false;
        }
    }


    void Shoot()
    {
        if (!canShoot) return;

        canShoot = false;

        AudioManager.instance.PlaySFX(3);
        GameObject actualBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        Bullet bulletScript = actualBullet.GetComponent<Bullet>();
        bulletScript.isFacingRight = isFacingRight;
        Invoke(nameof(ResetShoot), shootCooldown);
    }

    void StopShoot()
    {
        anim.SetBool("Shoot", false);
    }
    void ResetShoot()
    {
        canShoot = true;
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    #region Inputs

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && !dmgr) Jump();
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        if (context.performed && canShoot)
        {
            anim.SetBool("Shoot", true);
            //Shoot();
        }
    }

    void AnimationManagement() 
    {
        anim.SetBool("Jump", !isGrounded);
        if (moveInput.x != 0) anim.SetBool("Walk", true);
        else anim.SetBool("Walk", false);
        if (dmgr) anim.SetBool("Dmg", true);
    }

    #endregion


}
