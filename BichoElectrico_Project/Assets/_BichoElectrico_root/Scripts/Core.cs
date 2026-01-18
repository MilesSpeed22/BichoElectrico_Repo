using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour
{

    public int health = 5;
    public GameObject sceneBefore;
    public GameObject sceneAfter;
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
            sceneBefore.SetActive(false);
            sceneAfter.SetActive(true);
        }
    }
}
