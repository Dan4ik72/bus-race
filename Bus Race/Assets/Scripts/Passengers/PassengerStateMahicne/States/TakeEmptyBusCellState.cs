using UnityEngine;
using UnityEngine.Events;

public class TakeEmptyBusCellState : BusInteractionState
{
    private Transform _targetPlace;

    private float _targetReachedDistance = 0.2f;
    private float _speed;

    private IMoveHandler _moveHandler;
    private DefaultPassengerSetUp _passenger;

    public event UnityAction TakeEmptyBusCellStateEntered;

    public TakeEmptyBusCellState(StateMachine stateMachine, Transform passengerTransform, IMoveHandler moveHandler, float speed,DefaultPassengerSetUp passenger) : base(stateMachine, passengerTransform) 
    {
        _moveHandler = moveHandler;
        _passenger = passenger;
        _speed = speed;
    }

    public void SetTargetCell(Transform targetCell)
    {
        _targetPlace = targetCell;
    }

    public override void Enter()
    {
        TakeEmptyBusCellStateEntered?.Invoke();
    }

    public override void Update()
    {
        if (_targetPlace == null)
            return;

        MoveToTargetCell(_targetPlace);

        if (Vector3.Distance(PassengerTransform.position, _targetPlace.transform.position) < _targetReachedDistance)
        {
            StateMachine.SetState<RidingOnBusState>();
        }
    }

    private void MoveToTargetCell(Transform targetPlace)
    {
        Vector3 direction = targetPlace.position - PassengerTransform.position;
        direction.Normalize();

        _moveHandler.Move(direction , _speed);
    }
}
