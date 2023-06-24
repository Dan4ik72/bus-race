using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingOnBusState : BusInteractionState
{
    public RidingOnBusState(StateMachine stateMachine, Transform passengerTransform) : base(stateMachine, passengerTransform) { }

    public override void Enter()
    {
        //Debug.Log("Entered");
    }
}
