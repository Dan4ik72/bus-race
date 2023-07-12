using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBusCompositeRoot : CompositeRoot
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BusConfig _busConfig;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private Transform _passengersParent;
    [SerializeField] private BusPassengerZone _passengersZone;
    [SerializeField] private BusEntryPointTrigger _entryPointTrigger;
    [SerializeField] private GameCompositeRoot _gameCopmositeRoot;
    [SerializeField] private ModifiersCatcher _modifiersCatcher;
    [SerializeField] private DataStorageCompositeRoot _dataStorageCompositeRoot;
    
    [Header("Bus Parts")]
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _backWall;
    [SerializeField] private Transform _frontWall;

    private BusMover _mover;
    private EnemyBusInputSetUp _enemyBusInputSetUp;
    private RigidbodyMoveHandler _rigidbodyMoveHandler;
    private BusPartsExpandHandler _partsExpandedHandler;
    private BusPassengers _passengersCollector;
    private BusFarePaymentService _busFarePaymentService;

    public override void Compose()
    {
        _busFarePaymentService = new BusFarePaymentService(_dataStorageCompositeRoot.PlayerMoneyDataStorage, _dataStorageCompositeRoot.PlayerBusDataStorage.GetData());
        _rigidbodyMoveHandler = new RigidbodyMoveHandler(_rigidbody);
        _passengersCollector = new BusPassengers(_passengersParent, _passengersZone, _busFarePaymentService);
        _entryPointTrigger.Init(_passengersCollector);
        _mover = new BusMover(_busConfig.GasSpeed, _rigidbodyMoveHandler);
        _enemyBusInputSetUp = new EnemyBusInputSetUp(_mover, _raycastPoint, _busConfig, _entryPointTrigger);
        _partsExpandedHandler = new BusPartsExpandHandler(_rightWall, _leftWall, _backWall, _frontWall);
        _modifiersCatcher.Init(_entryPointTrigger, _passengersCollector);
    }

    private void SubscribeEvents()
    {
        _gameCopmositeRoot.GameLoopSetUp.MainGameCycleStarted += _enemyBusInputSetUp.Enable;
        _passengersZone.GridExpandedWithValue += _partsExpandedHandler.OnExpand;
    }

    private void UnsubscribeEvents()
    {
        _gameCopmositeRoot.GameLoopSetUp.MainGameCycleStarted -= _enemyBusInputSetUp.Enable;
        _passengersZone.GridExpandedWithValue -= _partsExpandedHandler.OnExpand;
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        _enemyBusInputSetUp.OnDisable();
        UnsubscribeEvents();   
    }

    private void Update()
    {
        _enemyBusInputSetUp.Update();
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }
}

