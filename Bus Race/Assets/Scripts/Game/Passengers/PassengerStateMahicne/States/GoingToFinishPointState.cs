using UnityEngine;

public class GoingToFinishPointState : State
{
    private DefaultPassengerSetUp _passenger;
    private Vector3 _finishPoint;

    private float _movingSpeed;
    private float _finishPointRandomOffcet;

    private IMoveHandler _moveHandler;

    public GoingToFinishPointState(StateMachine stateMachine, DefaultPassengerSetUp passenger, IMoveHandler moveHandler, float movingSpeed) : base(stateMachine)
    {
        _passenger = passenger;
        _movingSpeed = movingSpeed;
        _moveHandler = moveHandler;
    }

    public override void Enter()
    {
        _passenger.transform.parent = null;

        _finishPointRandomOffcet = Random.Range(3f, 8f);
        _finishPoint = new Vector3(_passenger.FinishPoint.position.x + Random.Range(-2f, 2f), _passenger.FinishPoint.position.y, _passenger.FinishPoint.position.z + Random.Range(-2f, 2f));
    }

    public override void Update()
    {
        MoveToFinishPoint();
    }

    private void MoveToFinishPoint()
    {
        if (Vector3.Distance(_passenger.transform.position, _finishPoint) < 0.5f)
            return;

        Vector3 direction = (_finishPoint - _passenger.transform.position ).normalized;

        _moveHandler.Move(direction, _movingSpeed);
        _moveHandler.Rotate(direction, _movingSpeed);
    }
}
