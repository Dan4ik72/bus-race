using UnityEngine;

public class ModifiersCatcher : MonoBehaviour
{
    private BusEntryPointTrigger _busEntryPointTrigger;
    private BusPassengers _passengersCollector;
    private BusMover _busMover;

    private bool _isPlayerBus;

    public void Init(BusEntryPointTrigger busEntryPointTrigger, BusPassengers passengerCollector, BusMover busMover, bool isPlayerBus)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _passengersCollector = passengerCollector;
        _busMover = busMover;

        _isPlayerBus = isPlayerBus;
    }

    public bool IsPlayerBus => _isPlayerBus;
    public BusMover BusMover => _busMover;
    public BusEntryPointTrigger BusEntryPointTrigger => _busEntryPointTrigger;
    public BusPassengers PassengerCollector => _passengersCollector;
}