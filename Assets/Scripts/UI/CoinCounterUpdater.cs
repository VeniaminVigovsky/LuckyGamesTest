using UnityEngine;
using UnityEngine.UI;
public class CoinCounterUpdater : MonoBehaviour
{
    private Text _text;
    private void Awake()
    {
        _text = GetComponent<Text>();
        UpdateCoinCount(Stats.CoinCount);
    }

    private void OnEnable()
    {
        Stats.OnCoinCountChanged += UpdateCoinCount;
    }
    private void OnDisable()
    {
        Stats.OnCoinCountChanged -= UpdateCoinCount;
    }

    private void UpdateCoinCount(int count)
    {
        _text.text = $"Coins: {count}";
    }
}
