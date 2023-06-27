using UnityEngine;

public class PlayerBusCompositeRoot : CompositeRoot
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private BusConfig _config;
    [SerializeField] private BusPassengerZone _passengerZone;
    [SerializeField] private BusEntryPointTrigger _entryPointTrigger;
    [SerializeField] private Transform _passengerParent;
    [SerializeField] private GameCompositeRoot _gameCompositeRoot;

    private BusMover _mover;
    private Bus _bus;
    private PlayerBusInputSetUp _inputSetUp;
    private RigidbodyMoveHandler _moveHandler;
    private BusPassengers _passegners;

    public BusMover Mover => _mover;
    public Bus Bus => _bus;
    public PlayerBusInputSetUp InputSetUp => _inputSetUp;
    public BusPassengerZone PassengerZone => _passengerZone;
    public BusEntryPointTrigger EntryPointTrigger => _entryPointTrigger;
    public RigidbodyMoveHandler MoveHandler => _moveHandler;
    public BusPassengers Passengers => _passegners;

    public override void Compose()
    {
        _passegners = new BusPassengers(_passengerParent, _passengerZone);
        _entryPointTrigger.Init(_passegners);
        _moveHandler = new RigidbodyMoveHandler(_rigidbody);
        _mover = new BusMover(_config.IdleSpeed, _config.GasSpeed, _moveHandler);
        _inputSetUp = new PlayerBusInputSetUp(_mover, _raycastPoint, _config);
    }

    private void Start()
    {
        _mover.SetIdleSpeed();
    }

    private void OnEnable()
    {
        _gameCompositeRoot.GameLoopSetUp.MainGameCycleStarted += _inputSetUp.Enable;
    }

    private void OnDisable()
    {
        _gameCompositeRoot.GameLoopSetUp.MainGameCycleStarted  -= _inputSetUp.Enable;
    }

    private void Update()
    {
        _inputSetUp.Update();
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }
}
