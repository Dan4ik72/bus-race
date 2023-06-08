using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class BusCompositeRoot : CompositeRoot
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BusConfig _config;
    [SerializeField] private PassengerZone _passengerZone;

    private BusMover _mover;
    private Bus _bus;
    private BusInputSetUp _inputSetUp;
    private RigidbodyMoveHandler _moveHandler;

    public BusMover Mover => _mover;
    public Bus Bus => _bus;
    public BusInputSetUp InputSetUp => _inputSetUp;
    public PassengerZone PassengerZone => _passengerZone;
    public RigidbodyMoveHandler MoveHandler => _moveHandler;

    public override void Compose()
    {
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
