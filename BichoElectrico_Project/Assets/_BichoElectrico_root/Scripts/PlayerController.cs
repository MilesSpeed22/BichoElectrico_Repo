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


    [Header("Shooting Config")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootCooldown = 1f;
    bool canShoot;
    
    Rigidbody2D PlayerRb;
    PlayerInput input;
    Vector2 moveInput;
    Animator anim;
    [SerializeField] Transform respawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        isGrounded = true;
        canShoot = true;
    }

    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
        PlayerRb.linearVelocity = new Vector2(moveInput.x * speed, PlayerRb.linearVelocity.y);
    }

    void Jump()
    {
        PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        
    }

    void Shoot()
    {
        canShoot = false;
        GameObject actualBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        Bullet bulletScript = actualBullet.GetComponent<Bullet>();
        bulletScript.isFacingRight = isFacingRight;
        Invoke(nameof(ResetShoot), shootCooldown);
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
            SceneManager.LoadScene(0);
        }
    }

    void Respawn()
    {
        PlayerRb.linearVelocity = Vector3.zero;
        PlayerRb.angularVelocity = 0f;
        transform.position = respawnPoint.position;
    }


    #region Inputs

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) Jump();
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        if (context.performed && canShoot) Shoot();
    }

    void AnimationManagement() 
    {
        anim.SetBool("Jump", !isGrounded);
        if (moveInput.x != 0f) anim.SetBool("Run", true);
        else anim.SetBool("Run", false);
    }

    #endregion


}
