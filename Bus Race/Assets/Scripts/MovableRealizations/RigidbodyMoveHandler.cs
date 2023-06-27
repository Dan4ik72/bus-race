using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class RigidbodyMoveHandler : IMoveHandler
{
    private Rigidbody _rigidbody;

    public RigidbodyMoveHandler(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction * Time.fixedDeltaTime;
    }

    public void Rotate(Vector3 targetPosition, float speed)
    {
        _rigidbody.transform.LookAt(targetPosition);
    }
}
