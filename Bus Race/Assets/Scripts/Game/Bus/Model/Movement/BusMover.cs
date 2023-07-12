using UnityEngine;

public class BusMover
{
    private float _currentSpeed;

    private float _idleSpeed = 0;
    private float _gasSpeed;

    private IMoveHandler _moveHandler;

    private Vector3 _direction = new Vector3(1, 0, 0);

    public BusMover(float gasSpeed, IMoveHandler moveHandler)
    {
        _gasSpeed = gasSpeed;
        _moveHandler = moveHandler;
    }

    public void SetGasSpeed()
    {
        _currentSpeed = _gasSpeed;
    }

    public void SetIdleSpeed()
    {
        _currentSpeed = _idleSpeed;
    }

    public void Move()
    {
        Vector3 moveVector = _direction;
        _moveHandler.Move(moveVector, _currentSpeed);
    }
}