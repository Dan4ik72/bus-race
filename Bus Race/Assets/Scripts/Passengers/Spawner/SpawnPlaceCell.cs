using UnityEngine;

public class SpawnPlaceCell : MonoBehaviour, ICell
{
    public float Heigh { get; } = 0.8f;
    public float Width { get; } = 0.8f;

    public Transform GetTransform()
    {
        return transform;
    }
}
