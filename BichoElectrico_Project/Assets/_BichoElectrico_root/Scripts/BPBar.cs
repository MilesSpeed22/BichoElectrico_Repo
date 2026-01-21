using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BPBar : MonoBehaviour
{
    public UnityEngine.UI.Image bateryBarFill;
    private PlayerController playerController;
    private float MaxBP;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        MaxBP = playerController.Batery;
    }

    // Update is called once per frame
    void Update()
    {
        bateryBarFill.fillAmount = playerController.Batery / MaxBP;
    }
}
