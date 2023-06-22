using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusPlaceCell : MonoBehaviour, ICell
{
    public int Width { get; } = 1;
    public int Heigh { get; } = 1;

    public Transform GetTransform() => transform;
}
