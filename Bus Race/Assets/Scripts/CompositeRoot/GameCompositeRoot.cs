using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCompositeRoot : CompositeRoot
{
    [SerializeField] private List<Modifier> _modifiers;
    [SerializeField] private PassengerCompositeRoot _passengerCompositeRoot;
    [SerializeField] private GameEndingTrigger _gameEndingTrigger;
    [SerializeField] private Transform _playerFinishPoint, _enemyFinishPoint;

    private GameLoopSetUp _gameLoopSetUp;

    public GameLoopSetUp GameLoopSetUp => _gameLoopSetUp;
    public Transform PlayerFinishPoint => _playerFinishPoint;
    public Transform EnemyFinishPoint => _enemyFinishPoint;


    public override void Compose()
    {
        _gameLoopSetUp = new GameLoopSetUp(_gameEndingTrigger);
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
}