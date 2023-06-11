using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusEntryPointTrigger : MonoBehaviour
{
    private BusPassengerZone _passengerZone;
    private BusPassengers _busPassengers;

    public void Init(BusPassengerZone passengerZone, BusPassengers passengersList)
    {
        _passengerZone = passengerZone;
        _busPassengers = passengersList;
    }

    public Cell GetAvailableCell(PassengerStateMachineSetUp passegner)
    {
        Cell availableCell = _passengerZone.GetAvailableCell();
        _busPassengers.AddPassegner(passegner, availableCell);

        return availableCell;
    }
}
