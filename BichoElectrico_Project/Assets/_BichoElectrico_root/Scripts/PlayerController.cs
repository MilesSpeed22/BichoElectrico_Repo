using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D PlayerRb;
    PlayerInput input;
    Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        isGrounded = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


    #region Inputs

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) Jump();
    }

    #endregion


}
