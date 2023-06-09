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
        _transform.position = Vector3.MoveTowards(_transform.position, direction, Time.deltaTime);
    }
}
