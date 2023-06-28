using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RidingOnBusState : BusInteractionState
{
    private float _yPassengerRotation = 90;

    private IMoveHandler _moveHandler;

    public event UnityAction RidingOnBusStateEntered;

    public RidingOnBusState(StateMachine stateMachine, Transform passengerTransform, IMoveHandler moveHandler) : base(stateMachine, passengerTransform) 
    {
        _moveHandler = moveHandler;
    }

    public override void Enter()
    {
        RidingOnBusStateEntered?.Invoke();

        PassengerTransform.transform.rotation = Quaternion.Euler(PassengerTransform.rotation.x, _yPassengerRotation, PassengerTransform.rotation.z);
    }
}
