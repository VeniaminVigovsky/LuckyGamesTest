using UnityEngine;
public class MainMenuManager : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = GetComponent<SceneLoader>();
    }

    public void StartGame()
    {        
        if (_sceneLoader == null) return;

        _sceneLoader.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
