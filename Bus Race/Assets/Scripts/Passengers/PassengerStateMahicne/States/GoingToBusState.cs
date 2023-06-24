using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToBusState : BusInteractionState
{
    private DefaultPassengerSetUp _passenger;

    private IMoveHandler _moveHandler;
    private float _moveSpeed;

    private float _minDistanceToBusTrigger = 0.5f;
    private float _maxDistanceToBusTrigger;

    public GoingToBusState(StateMachine stateMachine, DefaultPassengerSetUp passenger, IMoveHandler moveHandler, float moveSpeed, float maxDistanceToBusTrigger) : base(stateMachine, passenger.transform) 
    {
        _moveHandler = moveHandler;
        _passenger = passenger;
        _moveSpeed = moveSpeed;
        _maxDistanceToBusTrigger = maxDistanceToBusTrigger;
    }

    public override void Update()
    {
        if (GetDistanceToBusTrigger() < _maxDistanceToBusTrigger)
            MoveToBusTigger();
        else
            StateMachine.SetState<WaitingForBusState>();

        if (GetDistanceToBusTrigger() <= _minDistanceToBusTrigger)
            _passenger.BusEntryPointTrigger.EnterBus(_passenger);
    }

    private void MoveToBusTigger()
    {
        Vector3 direction = (_passenger.BusEntryPointTrigger.transform.position - PassengerTransform.position).normalized;

        _moveHandler.Move(direction * _moveSpeed);
    }

    private float GetDistanceToBusTrigger()
    {
        return Vector3.Distance(_passenger.BusEntryPointTrigger.transform.position, PassengerTransform.position);
    }
}
