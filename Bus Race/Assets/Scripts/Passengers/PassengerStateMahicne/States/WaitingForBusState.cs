using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForBusState : BusInteractionState
{
    private float _maxDistanceToBusTrigger;

    public WaitingForBusState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform, float maxDistanceToBusTrigger) : base(stateMachine, busEntryPointTrigger, passengerTransform)
    {
        _maxDistanceToBusTrigger = maxDistanceToBusTrigger;
    }

    public override void Update()
    {
        if (Vector3.Distance(PassengerTransform.position, BusEntryPointTrigger.transform.position) < _maxDistanceToBusTrigger)
            StateMachine.SetState<GoingToBusState>();
    }
}
