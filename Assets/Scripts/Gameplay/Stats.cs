using System;
public static class Stats
{
    private static int _coinCount;

    public static Action<int> OnCoinCountChanged;

    public static int CoinCount
    {
        get => _coinCount;

        set
        {
            if (value >= 0)
            {
                _coinCount = value;
                OnCoinCountChanged?.Invoke(_coinCount);
            }
        }
    }
}
