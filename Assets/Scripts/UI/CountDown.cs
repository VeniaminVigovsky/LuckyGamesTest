using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    private Text _text;

    private int _countNum = 3;
    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    private void Update()
    {
        int n = _countNum - (int)GameplayManager.ElapsedTime;        

        if (n <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            _text.text = n.ToString();
        }
    }
}
