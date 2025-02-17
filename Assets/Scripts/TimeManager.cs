using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{

    public float duration = 20f;
    public event Action OnTimeOver;
    public bool Running { get; private set; }
    public float RemainingTime { get; private set; }

    public void Update()
    {
        if (Running)
        {
            Tick(Time.deltaTime);
        }
    }

    private void Tick(float deltaTime)
    {
        RemainingTime -= deltaTime;
        if (RemainingTime <= 0f)
        {
            RemainingTime = 0f;
            OnTimeOver?.Invoke();
        }
    }

    public void reset()
    {
        RemainingTime = duration;
    }

    public void StartTimer()
    {
        Running = true;
    }

    public void StopTimer()
    {
        Running = false;
    }

}
