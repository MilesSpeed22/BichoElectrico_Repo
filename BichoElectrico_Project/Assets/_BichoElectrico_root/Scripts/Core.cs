using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour
{

    public int health = 1;
    public GameObject sceneBefore;
    public GameObject sceneAfter;
    public Explosion explosion;
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
            health = health - 1;

            other.gameObject.SetActive(false);

            if (health <= 0)
            {
                sceneChange();
            }
        }

        void sceneChange()
        {
            AudioManager.instance.PlaySFX(5);
            AudioManager.instance.PlayMusic(2);
            explosion.ExplosionEffect();

            sceneBefore.SetActive(false);
            sceneAfter.SetActive(true);


        }
    }
}
