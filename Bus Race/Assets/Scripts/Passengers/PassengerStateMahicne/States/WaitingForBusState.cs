using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForBusState : BusInteractionState
{
    public WaitingForBusState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform) : base(stateMachine, busEntryPointTrigger, passengerTransform) { }

    public override void Update()
    {
        if (Vector3.Distance(PassengerTransform.position, BusEntryPointTrigger.transform.position) < MaxDistanceToBusTigger)
            StateMachine.SetState<GoingToBusState>();
    }
}
