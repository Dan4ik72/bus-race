using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
