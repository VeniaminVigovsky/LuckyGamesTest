using UnityEngine;
public class PauseHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel;

    public void PauseGame()
    {
        if (_pausePanel == null) return;
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        if (_pausePanel == null) return;
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
