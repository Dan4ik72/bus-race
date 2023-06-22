using UnityEngine;

public class ModifiersTrigger : MonoBehaviour
{
    private PassengersSpawner _spawner;
    private BusEntryPointTrigger _busEntryPointTrigger;
    private BusPassengers _passengersCollector;

    public void Init(PassengersSpawner spawner, BusEntryPointTrigger busEntryPointTrigger, BusPassengers passengerCollector)
    {
        _spawner = spawner;
        _busEntryPointTrigger = busEntryPointTrigger;
        _passengersCollector = passengerCollector;
    }

    public PassengersSpawner Spawner => _spawner;
    public BusEntryPointTrigger BusEntryPointTrigger => _busEntryPointTrigger;
    public BusPassengers PassengerCollector => _passengersCollector;
}