using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float targetZ = 10f;
    [SerializeField] private float speed = 13f;

    private float startingZ;
    private bool movingToTarget = true;

    private void Start()
    {
        startingZ = transform.position.z;
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
        float newZ = Mathf.MoveTowards(transform.position.z, targetZ, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        if (Mathf.Approximately(transform.position.z, targetZ))
            movingToTarget = false;
    }

    private void MoveBack()
    {
        float newZ = Mathf.MoveTowards(transform.position.z, startingZ, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        if (Mathf.Approximately(transform.position.z, startingZ))
            movingToTarget = true;
    }
}
