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

    public void Spawn()
    {
        var created = Object.Instantiate(_passengerTemplate, new Vector3(-18.32f, 0.30f, -4.6f), Quaternion.identity);
        created.Init(_busEntryPointTrigger);
    }
}
