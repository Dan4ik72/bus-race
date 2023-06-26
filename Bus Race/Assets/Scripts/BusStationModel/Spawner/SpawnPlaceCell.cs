using UnityEngine;

public class SpawnPlaceCell : MonoBehaviour, ICell
{
    public float Heigh { get; } = 0.9f;
    public float Width { get; } = 0.9f;

    public Transform GetTransform()
    {
        return transform;
    }
}
