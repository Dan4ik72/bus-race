using UnityEngine;

public class DefaultPassengerSetUp : MonoBehaviour, IPassengerSetUp
{
    private StateMachine _stateMachine;
    private BusEntryPointTrigger _busEntryPointTrigger;

    private IMoveHandler _moveHandler;

    private WaitingForBusState _waitingForBusState;
    private GoingToBusState _goingToBusState;
    private TakeEmptyBusCellState _takeEmptyBusCellState;
    private RidingOnBusState _ridingOnBusState;

    public Transform GetTransform() => transform;

    public IPassengerSetUp Init(BusEntryPointTrigger busEntryPointTrigger)
    {
        _busEntryPointTrigger = busEntryPointTrigger;

        SetStateMachineUp();

        return this;
    }

    public void TakeEmptyBusCell(Cell cell)
    {
        _takeEmptyBusCellState.SetTargetCell(cell);
        _stateMachine.SetState<TakeEmptyBusCellState>();
    }

    private void SetStateMachineUp()
    {
        _moveHandler = new TransformMoveHandler(transform);

        _stateMachine = new StateMachine();

        _waitingForBusState = new WaitingForBusState(_stateMachine, _busEntryPointTrigger, transform);
        _goingToBusState = new GoingToBusState(_stateMachine, _busEntryPointTrigger, this, _moveHandler);
        _ridingOnBusState = new RidingOnBusState(_stateMachine, _busEntryPointTrigger, transform);
        _takeEmptyBusCellState = new TakeEmptyBusCellState(_stateMachine, _busEntryPointTrigger, transform, _moveHandler, this);

        _stateMachine.AddState(_waitingForBusState);
        _stateMachine.AddState(_goingToBusState);
        _stateMachine.AddState(_takeEmptyBusCellState);
        _stateMachine.AddState(_ridingOnBusState);

        _stateMachine.SetState<WaitingForBusState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
