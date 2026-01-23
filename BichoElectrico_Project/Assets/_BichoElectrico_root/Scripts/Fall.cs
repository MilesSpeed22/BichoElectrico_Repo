using UnityEngine;

public class Fall : MonoBehaviour
{
    Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.bodyType = RigidbodyType2D.Static;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = GetComponent<PlayerController>();

        if (collision.CompareTag("Player"))
        {
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
