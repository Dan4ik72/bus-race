using UnityEngine.Events;

public class GameEndingHandler
{
    private BusPassengers _playerBusPassengers;
    private BusPassengers _enemyBusPassenger;

    public event UnityAction PlayerWon;
    public event UnityAction PlayerLost;

    public GameEndingHandler(BusPassengers playerBusPassengers, BusPassengers enemyBusPassenger)
    {
        _playerBusPassengers = playerBusPassengers;
        _enemyBusPassenger = enemyBusPassenger;
    }

    public void OnGameEnded()
    {
        if(_playerBusPassengers.Count >= _enemyBusPassenger.Count)
        {
            PlayerWon?.Invoke();

            return;
        }

        PlayerLost?.Invoke();
    }

    public void SetPlayerLose()
    {
        PlayerLost?.Invoke();
    }

    public void SetPlayerWon()
    {
        PlayerWon?.Invoke();
    }
}

