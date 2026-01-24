using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public int musicToPlay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayMusic(musicToPlay);
    }
}
