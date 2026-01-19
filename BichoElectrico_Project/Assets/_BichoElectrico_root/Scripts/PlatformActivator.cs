using Unity.Cinemachine;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    public PlatformActivated platform;
    private bool activated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated) return;
        
        if (collision.CompareTag("Player"))
        {
            platform.platformAct = true;
            activated = true;
            gameObject.SetActive(false);

            Debug.Log("Palanca activada");
        }
    }
}
