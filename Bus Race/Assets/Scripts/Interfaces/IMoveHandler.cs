using System.Collections;
using UnityEditor;
using UnityEngine;

public interface IMoveHandler
{
    void Move(Vector3 direction, float speed);
    void Rotate(Vector3 rotation, float speed);
}

