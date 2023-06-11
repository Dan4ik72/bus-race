using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingOnBusState : BusInteractionState
{
    public RidingOnBusState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform) : base(stateMachine, busEntryPointTrigger, passengerTransform) { }

    public override void Enter()
    {
        Debug.Log("Entered");
    }
}
