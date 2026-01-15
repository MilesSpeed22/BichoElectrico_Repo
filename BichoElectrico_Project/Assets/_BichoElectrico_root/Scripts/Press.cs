using System.Collections;
using UnityEngine;

public class Press : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform[] points;
    [SerializeField] int startingPoint;
    [SerializeField] float secWait;
    [SerializeField] bool waitMoment;

    int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        i = startingPoint;
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
       PressMovement();

    }



    private void PressMovement()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f && !waitMoment)
        {
            waitMoment = true;
            StartCoroutine (PressWait());
           
            
        }
        //Mueve la plataforma a la posicion que vale i actualmente
        //i define la "balda dentro de la estanteria" del array que contiene una posicion concreta
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
    }
    private IEnumerator PressWait()
    {
        yield return new WaitForSeconds(secWait); 
        i++; //Sumarle 1 a i = definir un nuevo punto a alcanzar 
        if (i == points.Length) //Chequear si i vale lo que mide el array
        {
            i = 0; //Resetea el valor de i para resetear el circuito
        }
        waitMoment = false;

    }

}
