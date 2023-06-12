using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusEntryPointTrigger : MonoBehaviour
{
    private BusPassengers _busPassengers;

    public void Init(BusPassengers passengersList)
    {
        _busPassengers = passengersList;
    }

    public void OnPassengerEntered(PassengerStateMachineSetUp passegner)
    {
        _busPassengers.AddPassegner(passegner);
    }
}
