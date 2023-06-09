using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeEmptyBusCellState : BusInteractionState
{
    private Cell _targetCell;

    private float _targetReachedDistance = 0.2f;

    public TakeEmptyBusCellState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform, IMoveHandler moveHandler) : base(stateMachine, busEntryPointTrigger, passengerTransform) { }

    public override void Enter()
    {
        _targetCell = BusEntryPointTrigger.GetAvailableCell();
    }

    public override void Update()
    {
        MoveToTargetCell(_targetCell);

        if (Vector3.Distance(PassengerTransform.position, _targetCell.Position) < _targetReachedDistance)
        {
            //StateMachine.SetState<WaitingForBusState>();
        }
    }

    private void MoveToTargetCell(Cell targetCell)
    {

    }
}
