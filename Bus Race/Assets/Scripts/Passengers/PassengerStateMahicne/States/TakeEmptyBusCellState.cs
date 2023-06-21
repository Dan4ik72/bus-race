using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeEmptyBusCellState : BusInteractionState
{
    private Cell _targetCell;

    private float _targetReachedDistance = 0.2f;
    private float _speed = 5f;

    private IMoveHandler _moveHandler;
    private DefaultPassengerSetUp _passenger;

    public TakeEmptyBusCellState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger , Transform passengerTransform, IMoveHandler moveHandler, DefaultPassengerSetUp passenger) : base(stateMachine, busEntryPointTrigger, passengerTransform) 
    {
        _moveHandler = moveHandler;
        _passenger = passenger;
    }

    public void SetTargetCell(Cell targetCell)
    {
        _targetCell = targetCell;
    }

    public override void Update()
    {
        if (_targetCell == null)
            return;

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
