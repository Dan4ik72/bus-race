using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusPlaceCell : MonoBehaviour, ICell
{
    public float Width { get; } = 0.7f;
    public float Heigh { get; } = 0.7f;

    public Transform GetTransform() => transform;
}
