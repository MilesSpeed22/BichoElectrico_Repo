using Unity.VisualScripting;
using UnityEngine;

public class Enemy_tutorial_controler : MonoBehaviour
{
    public Transform player;
    [SerializeField] float followRadious;
    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] float enemyHealth = 1f;
    [SerializeField] bool isFacingRight;
    [SerializeField] Vector2 initialPosition;


    public PlayerController playerr;
    private Rigidbody2D rb;
    private float movement;
    private Vector2 movementFollow;
    private float lastX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        initialPosition = rb.position;

        lastX = rb.position.x;

    }

    // Update is called once per frame
    void Update()
    {

        float distancetoplayer = Vector2.Distance(transform.position, player.position);
        if (distancetoplayer < followRadious)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            movementFollow = new Vector2(direction.x, direction.y);
            rb.MovePosition(rb.position + speed * Time.deltaTime * movementFollow);
        }
        else
        {

            movement = Mathf.PingPong(Time.time * speed, distance);
            rb.MovePosition(initialPosition + Vector2.right * movement);
        }

        HandleFlip(rb.position.x);

        EnemyHealth();

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 directiondmg = new Vector2(transform.position.x, 0);

        collision.gameObject.GetComponent<PlayerController>().dmg(directiondmg, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemyHealth = -1;
        }
    }

    void EnemyHealth()
    {
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
    void HandleFlip(float currentX)
    {
        if (currentX > lastX && !isFacingRight)
            Flip();
        else if (currentX < lastX && isFacingRight)
            Flip();

        lastX = currentX;
    }
}
