using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersSpawner
{
    private BusEntryPointTrigger _busEntryPointTrigger;

    private PassengerStateMachineSetUp _passengerTemplate;
    
    public PassengersSpawner(BusEntryPointTrigger busEntryPointTrigger, PassengerStateMachineSetUp passegnerTemplate)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _passengerTemplate = passegnerTemplate;
    }
}
