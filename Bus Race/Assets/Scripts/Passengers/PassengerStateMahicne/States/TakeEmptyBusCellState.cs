using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeEmptyBusCellState : BusInteractionState
{
    private Cell _targetCell;

    private float _targetReachedDistance = 1f;
    private float _speed = 5f;

    private IMoveHandler _moveHandler;
    private PassengerStateMachineSetUp _passenger;

    public TakeEmptyBusCellState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform, IMoveHandler moveHandler, PassengerStateMachineSetUp passenger) : base(stateMachine, busEntryPointTrigger, passengerTransform) 
    {
        _moveHandler = moveHandler;
        _passenger = passenger;
    }

    public override void Enter()
    {
        _targetCell = BusEntryPointTrigger.GetAvailableCell(_passenger);
    }

    public override void Update()
    {
        MoveToTargetCell(_targetCell);

        if (Vector3.Distance(PassengerTransform.position, _targetCell.transform.position) < _targetReachedDistance)
        {
            StateMachine.SetState<RidingOnBusState>();
        }
    }

    private void MoveToTargetCell(Cell targetCell)
    {
        Vector3 direction = targetCell.transform.position - PassengerTransform.position;
        direction.Normalize();

        _moveHandler.Move(direction * _speed);
    }
}
