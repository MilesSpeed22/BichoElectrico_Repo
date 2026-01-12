using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController controller = GetComponent<PlayerController>();

        if (controller != null )
        {
            controller.ApplyAirForce();
        }
    }
}
