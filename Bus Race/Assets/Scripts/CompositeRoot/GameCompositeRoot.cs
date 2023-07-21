using Unity.VisualScripting;
using UnityEngine;

public class GameCompositeRoot : CompositeRoot
{
    [Header("CompositeRoots")]
    [SerializeField] private PassengerCompositeRoot _passengerCompositeRoot;
    [SerializeField] private PlayerBusCompositeRoot _playerBusCompositeRoot;
    [SerializeField] private EnemyBusCompositeRoot _enemyBusCompositeRoot;
    [SerializeField] private DataStorageCompositeRoot _dataStorageCompositeRoot;

    private GameLoopSetUp _gameLoopSetUp;
    private GameEndingHandler _gameEndingHandler;

    public GameLoopSetUp GameLoopSetUp => _gameLoopSetUp;
    public GameEndingHandler GameEndingHandler => _gameEndingHandler;

    public override void Compose()
    {
        _gameEndingHandler = new GameEndingHandler(_playerBusCompositeRoot.Passengers, _enemyBusCompositeRoot.BusPassenger);
        _gameLoopSetUp = new GameLoopSetUp();

        Level currentLevel = _dataStorageCompositeRoot.LevelsDataStorageService.LevelsData.GetCurrentLevel().Level;
        Instantiate(currentLevel).Init(_passengerCompositeRoot.Spawner, _gameLoopSetUp);

    }

    private void Update()
    {
        _gameLoopSetUp.Update();
    }

    private void OnEnable()
    {
        _gameLoopSetUp.GameEndingStateStarted += _gameEndingHandler.OnGameEnded;
        _gameEndingHandler.PlayerWon += _dataStorageCompositeRoot.LevelsDataStorageService.LevelSelectHandler.IncrementCurrentLevel;
    }

    private void OnDisable()
    {
        _gameLoopSetUp.GameEndingStateStarted -= _gameEndingHandler.OnGameEnded;
        _gameLoopSetUp.GameEndingStateStarted -= _dataStorageCompositeRoot.LevelsDataStorageService.LevelSelectHandler.IncrementCurrentLevel;

        _dataStorageCompositeRoot.LevelsDataStorageService.SaveData();
    }
}