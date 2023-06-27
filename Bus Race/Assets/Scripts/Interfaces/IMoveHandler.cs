using UnityEditor;
using UnityEngine;

public interface IMoveHandler
{
    void Move(Vector3 direction);
    void Rotate(Vector3 rotation, float speed);
}

