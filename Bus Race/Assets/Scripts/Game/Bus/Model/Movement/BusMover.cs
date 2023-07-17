using UnityEngine;

public class BusMover
{
    private float _currentSpeed;

    private float _idleSpeed = 0;
    private float _gasSpeed;
    private float _maxGasSpeed;

    private IMoveHandler _moveHandler;

    private Vector3 _direction = new Vector3(1, 0, 0);

    public BusMover(float gasSpeed, float maxSpeed, IMoveHandler moveHandler)
    {
        _gasSpeed = gasSpeed;
        _maxGasSpeed = maxSpeed;
        _moveHandler = moveHandler;
    }

    public float GasSpeed => _gasSpeed;
    public float CurrentSpeed => _currentSpeed;

    public void SetGasSpeed(float gasSpeed)
    {
        if(gasSpeed < 0)
            throw new System.ArgumentOutOfRangeException(nameof(gasSpeed));

        _gasSpeed = Mathf.Clamp(gasSpeed, 0, _maxGasSpeed);

        SetGasState();
    }

    public void SetGasState()
    {
        _currentSpeed = _gasSpeed;
    }

    public void SetIdleState()
    {
        _currentSpeed = _idleSpeed;
    }

    public void Move()
    {
        Vector3 moveVector = _direction;
        _moveHandler.Move(moveVector, _currentSpeed);
    }
}