using UnityEngine;

public class PlayerBusCompositeRoot : CompositeRoot
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private BusConfig _config;
    [SerializeField] private BusPassengerZone _passengerZone;
    [SerializeField] private BusEntryPointTrigger _entryPointTrigger;
    [SerializeField] private Transform _passengerParent;
    [SerializeField] private ModifiersCatcher _modifiersTrigger;
    [SerializeField] private GameCompositeRoot _gameCompositeRoot;
    [SerializeField] private DataStorageCompositeRoot _dataStorageCompositeRoot;

    [Header("Bus Parts Transform")]
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _frontWall;
    [SerializeField] private Transform _backWall;
    
    private BusMover _mover;
    private Bus _bus;
    private PlayerBusInputSetUp _inputSetUp;
    private RigidbodyMoveHandler _moveHandler;
    private BusPassengers _passegners;
    private BusPartsExpandHandler _partsExpandHandler;
    private BusFarePaymentService _busFarePaymentService;

    public BusMover Mover => _mover;
    public Bus Bus => _bus;
    public PlayerBusInputSetUp InputSetUp => _inputSetUp;
    public BusPassengerZone PassengerZone => _passengerZone;
    public BusEntryPointTrigger EntryPointTrigger => _entryPointTrigger;
    public RigidbodyMoveHandler MoveHandler => _moveHandler;
    public BusPassengers Passengers => _passegners;
    public BusFarePaymentService BusFarePaymentService => _busFarePaymentService;

    public override void Compose()
    {
        _busFarePaymentService = new BusFarePaymentService(_dataStorageCompositeRoot.PlayerMoneyDataStorage, _dataStorageCompositeRoot.PlayerBusDataStorage.GetData());
        _partsExpandHandler = new BusPartsExpandHandler(_rightWall, _leftWall, _backWall, _frontWall);
        _passegners = new BusPassengers(_passengerParent, _passengerZone, _busFarePaymentService);
        _entryPointTrigger.Init(_passegners);
        _moveHandler = new RigidbodyMoveHandler(_rigidbody);
        _mover = new BusMover(_dataStorageCompositeRoot.PlayerBusDataStorage.GetData().BusSpeed, _moveHandler);
        _inputSetUp = new PlayerBusInputSetUp(_mover, _entryPointTrigger, _raycastPoint, _config);
        _modifiersTrigger.Init(_entryPointTrigger, _passegners, true);
    }

    private void SubscribeEvents()
    {
        _gameCompositeRoot.GameLoopSetUp.MainGameCycleStarted += _inputSetUp.Enable;
        _gameCompositeRoot.GameLoopSetUp.GameEndingStateStarted += _inputSetUp.SetGameEndingInputType;
        _gameCompositeRoot.GameLoopSetUp.GameEndingStateStarted += _busFarePaymentService.OnGameFinished;
        
        _passengerZone.GridExpandedWithValue += _partsExpandHandler.OnExpand;
    }

    private void UnsubscribeEvents()
    {
        _gameCompositeRoot.GameLoopSetUp.MainGameCycleStarted -= _inputSetUp.Enable;
        _gameCompositeRoot.GameLoopSetUp.GameEndingStateStarted -= _inputSetUp.SetGameEndingInputType;
        _gameCompositeRoot.GameLoopSetUp.GameEndingStateStarted -= _busFarePaymentService.OnGameFinished;

        _passengerZone.GridExpandedWithValue -= _partsExpandHandler.OnExpand;
    }

    private void Start()
    {
        _mover.SetIdleSpeed();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
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
