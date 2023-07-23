using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class GameBeginingTimerModel
{
    private GameLoopSetUp _gameLoopSetUp;

    public event UnityAction TimerStarted;
    public event UnityAction<int> ValueChanged;
    public event UnityAction TimerEnded;

    public GameBeginingTimerModel(GameLoopSetUp gameLoopSetUp)
    {
        _gameLoopSetUp = gameLoopSetUp;

        _gameLoopSetUp.GameBegan += OnGameStarted;
    }

    private void OnGameStarted()
    {
        TimerStarted?.Invoke();
        Coroutines.StartRoutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        ValueChanged?.Invoke(3);

        yield return new WaitForSecondsRealtime(1);
        ValueChanged?.Invoke(2);

        yield return new WaitForSecondsRealtime(1);
        ValueChanged?.Invoke(1);

        yield return new WaitForSecondsRealtime(1);

        TimerEnded?.Invoke();
        _gameLoopSetUp.GameBegan -= OnGameStarted;
    }
}

