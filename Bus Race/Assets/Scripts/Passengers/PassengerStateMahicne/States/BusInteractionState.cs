using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BusInteractionState : State
{
    private BusEntryPointTrigger _busEntryPointTrigger;
    private Transform _passengerTransform;

    public BusInteractionState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform) : base(stateMachine)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _passengerTransform = passengerTransform;
    }

    protected BusEntryPointTrigger BusEntryPointTrigger => _busEntryPointTrigger;
    protected Transform PassengerTransform => _passengerTransform;
}
