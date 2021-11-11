using UnityEngine;
public class WaitTimeState : IState
{
    private float _startTime;

    private float _duration;    

    public bool TimesUp
    {
        get => Time.time > _startTime + _duration;
    }   

    public WaitTimeState(float duration)
    {
        _duration = duration;
    }

    public void OnEnter()
    {
        _startTime = Time.time;
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        
    }
}
