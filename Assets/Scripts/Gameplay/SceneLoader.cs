using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int i)
    {
        if (i >= SceneManager.sceneCountInBuildSettings) return;
        SceneManager.LoadScene(i);
    }
}
