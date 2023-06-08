using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RigidbodyMoveHandler : IMoveHandler
{
    private Rigidbody _rigidbody;

    public RigidbodyMoveHandler(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Move(Vector3 direction, float deltaTime)
    {
        _rigidbody.velocity = direction * deltaTime;
    }
}
