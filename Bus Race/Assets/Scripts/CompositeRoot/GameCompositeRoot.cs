using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameCompositeRoot : CompositeRoot
{
    [Header("CompositeRoots")]
    [SerializeField] private PassengerCompositeRoot _passengerCompositeRoot;
    [SerializeField] private PlayerBusCompositeRoot _playerBusCompositeRoot;
    [SerializeField] private EnemyBusCompositeRoot _enemyBusCompositeRoot;

    [SerializeField] private List<Modifier> _modifiers;
    [SerializeField] private GameEndingTrigger _gameEndingTrigger;
    [SerializeField] private Transform _playerFinishPoint, _enemyFinishPoint;

    private GameLoopSetUp _gameLoopSetUp;
    private GameEndingHandler _gameEndingHandler;

    public GameLoopSetUp GameLoopSetUp => _gameLoopSetUp;
    public Transform PlayerFinishPoint => _playerFinishPoint;
    public Transform EnemyFinishPoint => _enemyFinishPoint;
    public GameEndingHandler GameEndingHandler => _gameEndingHandler;

    public override void Compose()
    {
        _gameLoopSetUp = new GameLoopSetUp(_gameEndingTrigger);
        _gameEndingHandler = new GameEndingHandler(_playerBusCompositeRoot.Passengers, _enemyBusCompositeRoot.BusPassenger);

        _gameLoopSetUp.GameEndingStateStarted += _gameEndingHandler.OnGameEnded;

        InitModifiers();
    }

    private void InitModifiers()
    {
        foreach (var modifier in _modifiers)
            modifier.Init(_passengerCompositeRoot.Spawner);
    }

    private void Update()
    {
        _gameLoopSetUp.Update();
    }

    private void OnDisable()
    {
        _gameLoopSetUp.GameEndingStateStarted -= _gameEndingHandler.OnGameEnded;
    }
}