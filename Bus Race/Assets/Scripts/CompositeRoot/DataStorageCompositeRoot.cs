using UnityEngine;

public class DataStorageCompositeRoot : CompositeRoot
{
    [SerializeField] private BusConfig _busConfig;

    private PlayerBusDataStorageService _playerBusDataStorage;

    private ISaveService _saveService;

    public PlayerBusDataStorageService PlayerBusDataStorage => _playerBusDataStorage;

    public override void Compose()
    {
        _saveService = new PlayerPrefsSaveService(); 
        _playerBusDataStorage = new PlayerBusDataStorageService(_saveService, _busConfig);
    }
}
