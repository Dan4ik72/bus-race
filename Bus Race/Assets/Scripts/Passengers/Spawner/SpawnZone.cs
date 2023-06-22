using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private SpawnPlaceCell _cellPrefab;
    [SerializeField] private Transform _cellsParent;

    [SerializeField] private Vector2 _gridCapacity;
    
    private Grid _grid;

    private List<Transform> _passengerSpawnPlaces = new List<Transform>();

    public IReadOnlyList<Transform> GetSpawnPlaces() => _passengerSpawnPlaces;
    public Transform CellsParent => _cellsParent;

    private void Awake()
    {
        CreateGrid();
    }
    
    private void CreateGrid()
    {
        _grid = new Grid(_cellsParent, _cellPrefab, _gridCapacity, 0.2f).Create();
        _passengerSpawnPlaces = _grid.Cells.ToList();
    }
}
