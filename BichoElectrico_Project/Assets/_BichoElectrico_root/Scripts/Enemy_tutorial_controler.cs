using UnityEngine;

public class Enemy_tutorial_controler : MonoBehaviour
{
    public Transform player;
    [SerializeField] float detectRadious;
    [SerializeField] float speed;
    [SerializeField] float enemyHealth = 1f;

    public PlayerController playerr;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancetoplayer = Vector2.Distance(transform.position, player.position);
        if (playerr.sneaky == false && distancetoplayer < detectRadious)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            movement = new Vector2(direction.x, direction.y);
        }
        else
        {
            movement = Vector2.zero;
        }

        EnemyHealth();

        rb.MovePosition(rb.position + speed * Time.deltaTime * movement);
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
}
