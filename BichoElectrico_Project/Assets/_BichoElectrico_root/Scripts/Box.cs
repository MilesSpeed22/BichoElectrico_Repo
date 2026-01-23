using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoxMovement();
    }

    void BoxMovement()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (collision.gameObject.tag != "BoxRemove")
        //{
            //gameObject.SetActive(false);
        //}
    //}
}
