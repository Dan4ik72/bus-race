using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float targetZ = 10f;
    [SerializeField] private float speed = 13f;
    [SerializeField] private bool _isRotateWhenMoveBack = false;

    private float startingZ;
    private bool movingToTarget = true;
    private float _originalYRotation;

    private void Start()
    {
        startingZ = transform.position.z;
        _originalYRotation = transform.rotation.y;
    }

    private void Update()
    {
        if (movingToTarget)
            MoveToTarget();
        else
            MoveBack();
    }

    private void MoveToTarget()
    {
        if (_isRotateWhenMoveBack && transform.rotation.y != _originalYRotation)
            transform.rotation = new Quaternion(transform.rotation.x, _originalYRotation, transform.rotation.z, transform.rotation.w);

        float newZ = Mathf.MoveTowards(transform.position.z, targetZ, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        if (Mathf.Approximately(transform.position.z, targetZ))
            movingToTarget = false;
    }

    private void MoveBack()
    {
        if (_isRotateWhenMoveBack)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z, transform.rotation.w);

        float newZ = Mathf.MoveTowards(transform.position.z, startingZ, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        if (Mathf.Approximately(transform.position.z, startingZ))
            movingToTarget = true;
    }
}
