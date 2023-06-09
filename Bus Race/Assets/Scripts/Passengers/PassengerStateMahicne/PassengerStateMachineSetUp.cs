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
        _moveHandler = new RigidbodyMoveHandler(GetComponent<Rigidbody>());

        _stateMachine = new StateMachine();

        _stateMachine.AddState(new WaitingForBusState(_stateMachine, _busEntryPointTrigger, transform));
        _stateMachine.AddState(new EnteringBusState(_stateMachine, _busEntryPointTrigger, transform, _moveHandler));
    }
}
