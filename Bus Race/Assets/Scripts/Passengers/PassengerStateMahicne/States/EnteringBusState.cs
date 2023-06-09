using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringBusState : BusInteractionState
{
    private IMoveHandler _moveHandler;
    private float _moveSpeed;

    public EnteringBusState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform, IMoveHandler moveHandler) : base(stateMachine, busEntryPointTrigger, passengerTransform) 
    {
        _moveHandler = moveHandler;
    } 

    public override void Update()
    {
        if (Vector3.Distance(BusEntryPointTrigger.transform.position, PassengerTransform.position) < MaxDistanceToBusTigger)
        {
            Vector3 direction = (BusEntryPointTrigger.transform.position - PassengerTransform.position).normalized;

            _moveHandler.Move(direction * _moveSpeed);
        }
        else
            StateMachine.SetState<WaitingForBusState>();
            
    }
}
