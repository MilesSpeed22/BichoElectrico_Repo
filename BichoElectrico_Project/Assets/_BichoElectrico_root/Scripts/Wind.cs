using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float windForce = 10f;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController controller = GetComponent<PlayerController>();

        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplyAirForce();
            }
        }
    }
}
