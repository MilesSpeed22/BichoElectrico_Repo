using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public float duration;
    public float fadeIn;
    public float fadeOut;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ExplosionEffect()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        explosion.SetActive(true);

        yield return new WaitForSeconds(duration);

        explosion.SetActive(false);
    }
}
