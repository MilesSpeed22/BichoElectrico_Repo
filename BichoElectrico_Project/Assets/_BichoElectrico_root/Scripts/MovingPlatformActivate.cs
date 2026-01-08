using UnityEngine;

public class MovingPlatformActivate2D : MonoBehaviour
{

    [Header("Waypoints and Movement config")]
    [SerializeField] float speed;
    [SerializeField] float waitSecs;
    [SerializeField] Transform[] points; //Array de puntos para perseguir por la plataforma, minimo 2
    [SerializeField] int startingPoint; //Define la posicion inicial de la plataforma
    public bool platformAct;

    int i; //Indice numerico = numero de punto a perseguir (punto actual +1, al llegar a final se resetea y va hacia el 0)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        i = startingPoint; //Definir el primer punto a perseguir
        //Setea la posicion incial de la plataforma a la posicion del starting point
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (platformAct == true)
        {
            PlatformMovement();
        }
        
    }



    void PlatformMovement()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //Sumarle 1 a i = definir un nuevo punto a alcanzar 
            if (i == points.Length) //Chequear si i vale lo que mide el array
            {
                i = 0; //Resetea el valor de i para resetear el circuito
            }
        }
        //Mueve la plataforma a la posicion que vale i actualmente
        //i define la "balda dentro de la estanteria" del array que contiene una posicion concreta
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (transform.position.y < collision.transform.position.y)
            {
                //El transform del objeto se hace hijo de la plataforma
                collision.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //el transform del objeto tiene como padre NULL = Ausencia de valor
            collision.transform.SetParent(null);
        }
    }
}

