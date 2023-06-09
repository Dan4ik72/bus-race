using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PassengerStateMachineSetUp : MonoBehaviour
{
    private StateMachine _stateMachine;
    private BusEntryPointTrigger _busEntryPointTrigger;

    private IMoveHandler _moveHandler;

    public void Init(BusEntryPointTrigger busEntryPointTrigger)
    {
        _busEntryPointTrigger = busEntryPointTrigger;

        SetStateMachineUp();
    }

    private void SetStateMachineUp()
    {
        _moveHandler = new TransformMoveHandler(transform);

        _stateMachine = new StateMachine();

        _stateMachine.AddState(new WaitingForBusState(_stateMachine, _busEntryPointTrigger, transform));
        _stateMachine.AddState(new GoingToBusState(_stateMachine, _busEntryPointTrigger, transform, _moveHandler));
        _stateMachine.AddState(new TakeEmptyBusCellState(_stateMachine, _busEntryPointTrigger, transform, _moveHandler));

        _stateMachine.SetState<WaitingForBusState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
