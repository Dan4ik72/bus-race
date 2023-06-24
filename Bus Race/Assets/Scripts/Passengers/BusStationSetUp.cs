using UnityEngine;
using UnityEngine.UIElements;

public class BusStationSetUp : MonoBehaviour
{ 
    [SerializeField] private PassengerSpawnZone _passengerSpawnZone;
    [SerializeField] private BusCatcher _busCatcher;

    [SerializeField] private PassengerConfig _passengerConfig;
    [SerializeField] private DefaultPassengerSetUp _defaultPassengerTemplate;

    private PassengersSpawner _spawner;

    private void Awake()
    {
        _spawner = new PassengersSpawner(_defaultPassengerTemplate);

        _passengerSpawnZone.Init(_spawner, _passengerConfig);
        _busCatcher.Init(_passengerSpawnZone);
    }
}
