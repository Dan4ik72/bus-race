using UnityEngine;

public class EnemyBusCompositeRoot : CompositeRoot
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BusConfig _busConfig;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private Transform _passengersParent;
    [SerializeField] private BusPassengerZone _passengersZone;
    [SerializeField] private BusEntryPointTrigger _entryPointTrigger;

    private BusMover _mover;
    private EnemyBusInputSetUp _enemyBusInputSetUp;
    private RigidbodyMoveHandler _rigidbodyMoveHandler;
    private BusPassengers _passengersCollector;

    public override void Compose()
    {
        _rigidbodyMoveHandler = new RigidbodyMoveHandler(_rigidbody);
        _passengersCollector = new BusPassengers(_passengersParent, _passengersZone);
        _entryPointTrigger.Init(_passengersCollector);
        _mover = new BusMover(_busConfig.IdleSpeed, _busConfig.GasSpeed, _rigidbodyMoveHandler);
        _enemyBusInputSetUp = new EnemyBusInputSetUp(_mover, _raycastPoint);
    }

    private void Awake()
    {
        _enemyBusInputSetUp.Awake();
    }

    private void OnEnable()
    {
        _enemyBusInputSetUp.OnEnable();        
    }

    private void OnDisable()
    {
        _enemyBusInputSetUp.OnDisable();
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

