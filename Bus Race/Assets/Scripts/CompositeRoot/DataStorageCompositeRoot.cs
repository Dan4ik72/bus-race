using UnityEngine;
using System.Collections.Generic;

public class DataStorageCompositeRoot : CompositeRoot
{
    [SerializeField] private BusConfig _busConfig;

    [Header("Levels")]
    [SerializeField] private List<LevelData> _levelsData; 

    private PlayerBusDataStorageService _playerBusDataStorage;
    private PlayerMoneyDataStorageService _playerMoneyDataStorage;

    private LevelsDataStorageService _levelsDataStorageService;

    private ISaveService _saveService;

    public PlayerBusDataStorageService PlayerBusDataStorage => _playerBusDataStorage;
    public PlayerMoneyDataStorageService PlayerMoneyDataStorage => _playerMoneyDataStorage;
    public LevelsDataStorageService LevelsDataStorageService => _levelsDataStorageService;
    public IReadOnlyList<LevelData> LevelsData => _levelsData;

    public override void Compose()
    {
        _saveService = new PlayerPrefsSaveService(); 

        _playerBusDataStorage = new PlayerBusDataStorageService(_saveService, _busConfig);
        _playerMoneyDataStorage = new PlayerMoneyDataStorageService(_saveService);

        _levelsDataStorageService = new LevelsDataStorageService(_saveService, _levelsData);

        //_levelsDataStorageService.LevelsData.SetCurrentLevelIndex(10);
        //_levelsDataStorageService.SaveData();
    }
}