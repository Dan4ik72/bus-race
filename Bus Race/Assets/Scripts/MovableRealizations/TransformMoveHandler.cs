using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMoveHandler : IMoveHandler
{
    private Transform _transform;

    public TransformMoveHandler(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        _transform.Translate(direction * Time.deltaTime);
    }
}
