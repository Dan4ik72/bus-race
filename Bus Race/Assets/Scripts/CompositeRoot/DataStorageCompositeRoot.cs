using Unity.VisualScripting;
using UnityEngine;

public class DataStorageCompositeRoot : CompositeRoot
{
    [Header("Composite Roots")]
    [SerializeField] private GameCompositeRoot _gameCompositeRoot;

    [SerializeField] private BusConfig _busConfig;

    private PlayerBusDataStorageService _playerBusDataStorage;
    private PlayerMoneyDataStorageService _playerMoneyDataStorage;

    private LevelsDataStorageService _levelsDataStorageService;

    private ISaveService _saveService;

    public PlayerBusDataStorageService PlayerBusDataStorage => _playerBusDataStorage;
    public PlayerMoneyDataStorageService PlayerMoneyDataStorage => _playerMoneyDataStorage;
    public LevelsDataStorageService LevelsDataStorageService => _levelsDataStorageService;

    public override void Compose()
    {
        PlayerPrefs.DeleteAll();

        _saveService = new PlayerPrefsSaveService(); 

        _playerBusDataStorage = new PlayerBusDataStorageService(_saveService, _busConfig);
        _playerMoneyDataStorage = new PlayerMoneyDataStorageService(_saveService);

        _levelsDataStorageService = new LevelsDataStorageService(_saveService, _gameCompositeRoot.LevelsData);
    }
}
