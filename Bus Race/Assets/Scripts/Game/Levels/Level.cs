using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameEndingTrigger _gameEndingTrigger;

    private List<Modifier> _modifiers = new List<Modifier>();
    private List<GameFinishObstacle> _obstacles = new List<GameFinishObstacle>();

    private PassengersSpawner _spawner;
    private GameLoopSetUp _gameLoopSetUp;
    private GameEndingHandler _gameEndingHandler;

    public void Init(PassengersSpawner spawner, GameLoopSetUp gameLoopSetUp, GameEndingHandler gameEndingHandler)
    {
        _spawner = spawner;
        _gameLoopSetUp = gameLoopSetUp;
        _gameEndingHandler = gameEndingHandler;

        _gameEndingTrigger = GetComponentInChildren<GameEndingTrigger>();
        _modifiers = GetComponentsInChildren<Modifier>().ToList();
        _obstacles = GetComponentsInChildren<GameFinishObstacle>().ToList();

        InitGameEndingTrigger();
        InitModifiers();
        InitObstacles();
    }

    public GameEndingTrigger GameEndingTrigger => _gameEndingTrigger;

    private void InitGameEndingTrigger()
    {
        _gameEndingTrigger.Init(_gameLoopSetUp);
    }

    private void InitObstacles()
    {
        foreach (var obstacle in _obstacles)
            obstacle.Init(_gameEndingHandler);
    }

    private void InitModifiers()
    {
        foreach (var modifier in _modifiers)
            modifier.Init(_spawner);
    }
}