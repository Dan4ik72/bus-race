using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class BusCompositeRoot : CompositeRoot
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BusConfig _config;
    [SerializeField] private BusPassengerZone _passengerZone;
    [SerializeField] private BusEntryPointTrigger _entryPointTrigger;
    [SerializeField] private Transform _passengerParent;

    private BusMover _mover;
    private Bus _bus;
    private BusInputSetUp _inputSetUp;
    private RigidbodyMoveHandler _moveHandler;
    private BusPassengers _passegners;

    public BusMover Mover => _mover;
    public Bus Bus => _bus;
    public BusInputSetUp InputSetUp => _inputSetUp;
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
        _inputSetUp = new BusInputSetUp(_mover);
    }

    private void Awake()
    {
        _inputSetUp.Awake();      
    }

    private void Start()
    {
        _mover.SetIdleSpeed();
    }

    private void OnEnable()
    {
        _inputSetUp.OnEnable();
    }

    private void OnDisable()
    {
        _inputSetUp.OnDisable();
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
