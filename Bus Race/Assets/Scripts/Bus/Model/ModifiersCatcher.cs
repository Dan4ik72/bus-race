using UnityEngine;

public class ModifiersCatcher : MonoBehaviour
{
    private BusEntryPointTrigger _busEntryPointTrigger;
    private BusPassengers _passengersCollector;

    public void Init(BusEntryPointTrigger busEntryPointTrigger, BusPassengers passengerCollector)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _passengersCollector = passengerCollector;
    }

    public BusEntryPointTrigger BusEntryPointTrigger => _busEntryPointTrigger;
    public BusPassengers PassengerCollector => _passengersCollector;
}