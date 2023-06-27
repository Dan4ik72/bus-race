using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public void Rotate(Vector3 rotation, float speed)
    {
        Quaternion toRotation = Quaternion.LookRotation(rotation);

        _transform.rotation = Quaternion.Lerp(_transform.rotation , toRotation, speed * Time.deltaTime);
    }
}
