using System;
public class PlayerDeathState : IState
{
    private Player _player;

    public static Action<bool> OnPlayerDied;

    public PlayerDeathState(Player player)
    {
        _player = player;
    }

    public void OnEnter()
    {
        OnPlayerDied?.Invoke(false);
        _player.gameObject.SetActive(false);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
