using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class TransformMoveHandler : IMoveHandler
{
    private Transform _transform;

    private float _smoothRotationVelocity;

    public TransformMoveHandler(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 direction, float speed)
    {
        _transform.position += direction * speed * Time.deltaTime;
    }

    public void Rotate(Vector3 rotation, float speed)
    {
        var targetYDirection = Quaternion.Slerp(_transform.rotation, Quaternion.LookRotation(rotation), speed * Time.deltaTime).y;

        _transform.rotation = new Quaternion(_transform.rotation.x, targetYDirection, _transform.rotation.z, _transform.rotation.w);
    }
}