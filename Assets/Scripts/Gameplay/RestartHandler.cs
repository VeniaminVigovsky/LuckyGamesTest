using UnityEngine;
using UnityEngine.UI;
public class RestartHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _restartPanel;

    private Text _text;

    private void Awake()
    {
        if (_restartPanel != null)
        {
            _text = _restartPanel.transform.GetComponentInChildren<Text>();
        }
    }

    private void OnEnable()
    {
        DoorController.OnLevelFinished += ShowRestartPanel;
        PlayerDeathState.OnPlayerDied += ShowRestartPanel;
    }

    private void OnDisable()
    {
        DoorController.OnLevelFinished -= ShowRestartPanel;
        PlayerDeathState.OnPlayerDied -= ShowRestartPanel;
    }

    private void ShowRestartPanel(bool win)
    {
        if (_restartPanel == null) return;
        Time.timeScale = 0;
        _restartPanel.SetActive(true);
        if (_text != null)
        {
            _text.text = win ? "VICTORY!" : "YOU ARE DEAD!";
        }
    }
}
