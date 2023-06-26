using System.Linq;
using UnityEngine;

public class BusStationSetUp : MonoBehaviour
{ 
    [SerializeField] private PassengerSpawnZone _passengerSpawnZone;
    [SerializeField] private BusCatcher _busCatcher;

    [SerializeField] private PassengerConfig _passengerConfig;
    [SerializeField] private DefaultPassengerSetUp _defaultPassengerTemplate;

    private PassengersSpawner _spawner;
    private BusStationPassengers _passengers;

    private void Awake()
    {
        _spawner = new PassengersSpawner(_defaultPassengerTemplate);
        _passengerSpawnZone.Init(_spawner, _passengerConfig);

        _passengers = new BusStationPassengers(_passengerSpawnZone.Passengers.ToList());

        _busCatcher.Init(_passengers);
    }
}
