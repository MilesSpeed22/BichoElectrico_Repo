using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float windForce = 10f;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController controller = GetComponent<PlayerController>();

        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.up * windForce * Time.deltaTime, ForceMode2D.Force);
            }
        }
    }
}
