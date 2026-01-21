using Unity.Cinemachine;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    public float health = 1;
    public PlatformActivated platform;
    private bool activated = false;

    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Activated();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Bullet"))
        {
            health = -1;
        }


    }
    
    public void Activated()
    {
        if (health < 0)
        {
            platform.platformAct = true;
            activated = true;
            anim.SetBool("Dec", true);


        }
    }
}
