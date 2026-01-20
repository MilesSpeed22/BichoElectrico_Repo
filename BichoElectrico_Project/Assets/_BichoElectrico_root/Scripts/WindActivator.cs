using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class WindActivator : MonoBehaviour
{
    public int health;
    Wind wind;
    SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health = -1;
            other.gameObject.SetActive(false);

            if (health < 0)
            {
                
                wind.isActive = true;
            }
        }
    }

}
