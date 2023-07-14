using UnityEngine;

public class ModifiersCatcher : MonoBehaviour
{
    private BusEntryPointTrigger _busEntryPointTrigger;
    private BusPassengers _passengersCollector;

    private bool _isPlayerBus;

    public void Init(BusEntryPointTrigger busEntryPointTrigger, BusPassengers passengerCollector, bool isPlayerBus)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _passengersCollector = passengerCollector;

        _isPlayerBus = isPlayerBus;
    }

    public bool IsPlayerBus => _isPlayerBus;
    public BusEntryPointTrigger BusEntryPointTrigger => _busEntryPointTrigger;
    public BusPassengers PassengerCollector => _passengersCollector;
}