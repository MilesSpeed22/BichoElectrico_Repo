using UnityEngine;
using UnityEngine.Rendering;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float firstShootTime;
    [SerializeField] float repeatShootTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(CannonShoot), firstShootTime, repeatShootTime);
    }

    void CannonShoot()
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity);
    }
}
