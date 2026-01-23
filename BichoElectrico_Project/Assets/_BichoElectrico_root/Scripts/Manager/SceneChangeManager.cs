using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void LoadScene(int SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
