using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private int _carCountToWin;
    
    private int _finishedCarsCount;

    public static event Action WonEvent;
    
    private void OnEnable()
    {
        Finish.CarFinishedEvent += OnCarFinished;
    }

    private void OnDisable()
    {
        Finish.CarFinishedEvent -= OnCarFinished;
    }

    private void OnCarFinished()
    {
        _finishedCarsCount++;
        if(_finishedCarsCount >= _carCountToWin)
            WonEvent?.Invoke();
    }
}
