using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private Grid _grid;

    [SerializeField] private Cell _cellPrefab;

    private List<Cell> _passengerSpawnPlaces = new List<Cell>();

    private void Awake()
    {
        CreateGrid();
    }

    public IReadOnlyList<Cell> GetSpawnPlaces()
    {
        return _passengerSpawnPlaces;
    }

    private void CreateGrid()
    {
        _grid = new Grid(transform, _cellPrefab, new Vector2Int((int)transform.localScale.x * 20, (int)transform.localScale.z * 10)).Create();

        _passengerSpawnPlaces = _grid.Cells.ToList();
    }
}
