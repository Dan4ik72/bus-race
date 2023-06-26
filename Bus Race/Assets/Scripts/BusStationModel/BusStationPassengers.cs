using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BusStationPassengers
{
    private List<DefaultPassengerSetUp> _passengers = new List<DefaultPassengerSetUp>();

    public event UnityAction BusStationEmpty;

    public BusStationPassengers(List<DefaultPassengerSetUp> passengers)
    {
        _passengers = passengers;
    }

    public bool IsBusStationEmpty => _passengers.Count == 0;

    public void SetBusEmptyPointTrigger(BusEntryPointTrigger busEmptyPointTrigger)
    {
        foreach (var passenger in _passengers)
        {
            passenger.SetBusEmptyPointTrigger(busEmptyPointTrigger);
        }

        _passengers.Clear();

        BusStationEmpty?.Invoke();
    }
}
