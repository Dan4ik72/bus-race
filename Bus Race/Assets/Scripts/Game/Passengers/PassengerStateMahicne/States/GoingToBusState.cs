using UnityEngine;
using UnityEngine.Events;

public class GoingToBusState : BusInteractionState
{
    private DefaultPassengerSetUp _passenger;

    private IMoveHandler _moveHandler;
    private float _moveSpeed;

    private float _minDistanceToBusTrigger = 0.5f;
    private float _maxDistanceToBusTrigger;

    public event UnityAction GoingToBusStateEntered;

    public GoingToBusState(StateMachine stateMachine, DefaultPassengerSetUp passenger, IMoveHandler moveHandler, float moveSpeed, float maxDistanceToBusTrigger) : base(stateMachine, passenger.transform) 
    {
        _moveHandler = moveHandler;
        _passenger = passenger;
        _moveSpeed = moveSpeed;
        _maxDistanceToBusTrigger = maxDistanceToBusTrigger;
    }

    public override void Enter()
    {
        GoingToBusStateEntered?.Invoke();
    }

    public override void Update()
    {
        if (GetDistanceToBusTrigger() < _maxDistanceToBusTrigger)
            MoveToBusTigger();
        else
            StateMachine.SetState<WaitingForBusState>();

        if (GetDistanceToBusTrigger() <= _minDistanceToBusTrigger)
        {
            _passenger.MeshRenderer.material = _passenger.BusEntryPointTrigger.BusMaterial;
            _passenger.BusEntryPointTrigger.EnterBus(_passenger);
        }
    }

    private void MoveToBusTigger()
    {
        Vector3 direction = (_passenger.BusEntryPointTrigger.transform.position - PassengerTransform.position).normalized;

        _moveHandler.Move(direction, _moveSpeed);
        _moveHandler.Rotate(direction, 100);
    }

    private float GetDistanceToBusTrigger()
    {
        return Vector3.Distance(_passenger.BusEntryPointTrigger.transform.position, PassengerTransform.position);
    }
}
