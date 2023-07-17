using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameCompositeRoot : CompositeRoot
{
    [SerializeField] private Level _test;

    [Header("CompositeRoots")]
    [SerializeField] private PassengerCompositeRoot _passengerCompositeRoot;
    [SerializeField] private PlayerBusCompositeRoot _playerBusCompositeRoot;
    [SerializeField] private EnemyBusCompositeRoot _enemyBusCompositeRoot;
    [SerializeField] private DataStorageCompositeRoot _dataStorageCompositeRoot;

    [SerializeField] private List<LevelData> _levelsData;

    private GameLoopSetUp _gameLoopSetUp;
    private GameEndingHandler _gameEndingHandler;

    public GameLoopSetUp GameLoopSetUp => _gameLoopSetUp;
    public GameEndingHandler GameEndingHandler => _gameEndingHandler;
    public List<LevelData> LevelsData => _levelsData;

    public override void Compose()
    {
        Level currentLevel = _dataStorageCompositeRoot.LevelsDataStorageService.LevelsData.GetCurrentLevel().Level;
        //Instantiate(currentLevel).Init(_passengerCompositeRoot.Spawner);

        _gameEndingHandler = new GameEndingHandler(_playerBusCompositeRoot.Passengers, _enemyBusCompositeRoot.BusPassenger);
        _gameLoopSetUp = new GameLoopSetUp();

        _gameLoopSetUp.GameEndingStateStarted += _gameEndingHandler.OnGameEnded;

        _test.Init(_passengerCompositeRoot.Spawner, _gameLoopSetUp);
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