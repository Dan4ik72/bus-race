using UnityEngine;

public class DefaultPassengerSetUp : MonoBehaviour, IPassengerSetUp
{
    private PassengerConfig _defaultPassengerConfig;

    private StateMachine _stateMachine;
    private BusEntryPointTrigger _busEntryPointTrigger;

    private IMoveHandler _moveHandler;

    private WaitingForBusState _waitingForBusState;
    private GoingToBusState _goingToBusState;
    private TakeEmptyBusCellState _takeEmptyBusCellState;
    private RidingOnBusState _ridingOnBusState;

    public void Init(PassengerConfig defaultPassengerConfig)
    {
        _defaultPassengerConfig = defaultPassengerConfig;

        SetStateMachineUp();
    }

    public BusEntryPointTrigger BusEntryPointTrigger => _busEntryPointTrigger;

    public Transform GetTransform() => transform;

    public void TakeEmptyBusCell(Transform cell)
    {
        _takeEmptyBusCellState.SetTargetCell(cell);
        _stateMachine.SetState<TakeEmptyBusCellState>();
    }

    public void SetBusEmptyPointTrigger(BusEntryPointTrigger busEntryPointTrigger)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _stateMachine.SetState<GoingToBusState>();
    }

    private void SetStateMachineUp()
    {
        _moveHandler = new TransformMoveHandler(transform);

        _stateMachine = new StateMachine();

        _waitingForBusState = new WaitingForBusState(_stateMachine, this, _defaultPassengerConfig.MaxDistanceToBusTrigger);
        _goingToBusState = new GoingToBusState(_stateMachine, this, _moveHandler, _defaultPassengerConfig.SpeedToBus, _defaultPassengerConfig.MaxDistanceToBusTrigger);
        _ridingOnBusState = new RidingOnBusState(_stateMachine, transform);
        _takeEmptyBusCellState = new TakeEmptyBusCellState(_stateMachine, transform, _moveHandler, _defaultPassengerConfig.SpeedInBus, this);

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
