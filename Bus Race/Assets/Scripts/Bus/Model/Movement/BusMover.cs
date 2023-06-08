using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMover
{
    private float _currentSpeed;

    private float _idleSpeed;
    private float _gasSpeed;

    private Rigidbody _rigidbody;

    private Vector3 _direction = new Vector3(1, 0, 0);

    public BusMover(float idleSpeed, float gasSpeed, Rigidbody rigidbody)
    {
        _idleSpeed = idleSpeed;
        _gasSpeed = gasSpeed;
        _rigidbody = rigidbody;
    }

    public void Start()
    {
        SetIdleSpeed();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void SetGasSpeed()
    {
        _currentSpeed = _gasSpeed;
    }

    public void SetIdleSpeed()
    {
        _currentSpeed = _idleSpeed;
    }

    private void Move()
    {
        _rigidbody.velocity = _direction * _currentSpeed * Time.fixedDeltaTime;
    }
}
