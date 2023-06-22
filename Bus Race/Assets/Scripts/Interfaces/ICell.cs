using UnityEngine;

public interface ICell
{
    public float Heigh { get; }
    public float Width { get; }

    public Transform GetTransform();
}

