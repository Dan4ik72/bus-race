using Unity.VisualScripting;
using UnityEngine;

public class DataStorageCompositeRoot : CompositeRoot
{
    [SerializeField] private BusConfig _busConfig;

    private PlayerBusDataStorageService _playerBusDataStorage;
    private PlayerMoneyDataStorageService _playerMoneyDataStorage;

    private ISaveService _saveService;

    public PlayerBusDataStorageService PlayerBusDataStorage => _playerBusDataStorage;
    public PlayerMoneyDataStorageService PlayerMoneyDataStorage => _playerMoneyDataStorage;

    public override void Compose()
    {
        _saveService = new PlayerPrefsSaveService(); 

        _playerBusDataStorage = new PlayerBusDataStorageService(_saveService, _busConfig);
        _playerMoneyDataStorage = new PlayerMoneyDataStorageService(_saveService);
    }
}
