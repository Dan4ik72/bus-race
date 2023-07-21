using UnityEngine;

public class DefaultPassengerSetUp : MonoBehaviour, IPassengerSetUp
{
    [SerializeField] private PassengerSkinHandler _skinHandler;

    [SerializeField] private SkinnedMeshRenderer _meshRenderer;

    private PassengerConfig _defaultPassengerConfig;

    private PassengerAnimationsPresenter _animationPresenter;

    private StateMachine _stateMachine;
    private BusEntryPointTrigger _busEntryPointTrigger;
    private Transform _finishPoint;
    
    private IMoveHandler _moveHandler;

    private WaitingForBusState _waitingForBusState;
    private GoingToBusState _goingToBusState;
    private TakeEmptyBusCellState _takeEmptyBusCellState;
    private RidingOnBusState _ridingOnBusState;

    private bool _isInBus = false;

    public void Init(PassengerConfig defaultPassengerConfig)
    {
        _defaultPassengerConfig = defaultPassengerConfig;

        SetUpServcies();
    }

    public BusEntryPointTrigger BusEntryPointTrigger => _busEntryPointTrigger;
    public Transform FinishPoint => _finishPoint;
    public bool IsInBus => _isInBus;
    public SkinnedMeshRenderer MeshRenderer => _meshRenderer;

    private void Update() => _stateMachine.Update();

    private void OnDisable() => _animationPresenter.UnsubscribeAnimationsHandlerOnStateEvents();

    public Transform GetTransform() => transform;

    public void SetTakeBusCellState(Transform cell)
    {
        _takeEmptyBusCellState.SetTargetCell(cell);
        _stateMachine.SetState<TakeEmptyBusCellState>();
        _isInBus = true;
    }

    public void SetGoingToBusTtate(BusEntryPointTrigger busEntryPointTrigger)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _stateMachine.SetState<GoingToBusState>();
    }

    private void SetUpServcies()
    {
        _skinHandler.Init();
        SetUpStateMachine();

        var animationHandler = new PassengerAnimationsHandler(_skinHandler.Animator);

        _animationPresenter = new PassengerAnimationsPresenter(animationHandler, _waitingForBusState, _goingToBusState, _takeEmptyBusCellState, _ridingOnBusState);
    }

    private void SetUpStateMachine()
    {
        _moveHandler = new TransformMoveHandler(transform);

        _stateMachine = new StateMachine();

        _waitingForBusState = new WaitingForBusState(_stateMachine, this, _defaultPassengerConfig.MaxDistanceToBusTrigger);
        _goingToBusState = new GoingToBusState(_stateMachine, this, _moveHandler, _defaultPassengerConfig.SpeedToBus, _defaultPassengerConfig.MaxDistanceToBusTrigger);
        _ridingOnBusState = new RidingOnBusState(_stateMachine, transform, _moveHandler);
        _takeEmptyBusCellState = new TakeEmptyBusCellState(_stateMachine, transform, _moveHandler, _defaultPassengerConfig.SpeedInBus, this);

        _stateMachine.AddState(_waitingForBusState);
        _stateMachine.AddState(_goingToBusState);
        _stateMachine.AddState(_takeEmptyBusCellState);
        _stateMachine.AddState(_ridingOnBusState);

        _stateMachine.SetState<WaitingForBusState>();
    }

}
