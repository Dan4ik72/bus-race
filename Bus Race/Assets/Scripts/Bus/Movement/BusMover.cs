using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BusMover : MonoBehaviour
{
    private float _currentSpeed;

    [SerializeField] private float _idleSpeed;
    [SerializeField] private float _gasSpeed;

    private Rigidbody _rigidbody;

    private Vector3 _direction = new Vector3(1, 0, 0);

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SetIdleSpeed();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Init(float gasSpeed, float idleSpeed)
    {
        //_idleSpeed = idleSpeed;
        //_gasSpeed = gasSpeed;
    }

    public void SetGasSpeed()
    {
        _currentSpeed = _gasSpeed;
        Debug.Log("Gas");
    }

    public void SetIdleSpeed()
    {
        _currentSpeed = _idleSpeed;
        Debug.Log("Idle");
    }

    private void Move()
    {
        _rigidbody.velocity = _direction * _currentSpeed * Time.fixedDeltaTime;
    }
}
