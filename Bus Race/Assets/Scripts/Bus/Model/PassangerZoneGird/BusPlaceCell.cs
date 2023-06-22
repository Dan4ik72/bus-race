using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusPlaceCell : MonoBehaviour, ICell
{
    public float Width { get; } = 1;
    public float Heigh { get; } = 1;

    public Transform GetTransform() => transform;
}
