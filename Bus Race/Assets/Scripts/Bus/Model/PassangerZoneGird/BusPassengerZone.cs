using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BusPassengerZone : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Vector2 _expandValue;

    private Grid _grid;

    private List<Cell> _availableCells = new List<Cell>();
    private List<Cell> _busyCells = new List<Cell>();

    private float _gridRandomness = 0.1f;

    public event UnityAction GridExpanded;

    private void Start() => CreateGrid();
    
    public Cell GetAvailableCell()
    {
        if (_availableCells.Count <= 0)
        {
            Expand();
        }

        Cell requestedCell = _availableCells.First();

        if (requestedCell == null)
            throw new System.Exception("There is no availableCell");

        _availableCells.Remove(requestedCell);
        _busyCells.Add(requestedCell);

        return requestedCell;
    }

    private void Expand()
    {
        transform.localScale = new Vector3(transform.localScale.x + _expandValue.x, transform.localScale.y, transform.localScale.z + _expandValue.y);
        _gridParent.transform.position = new Vector3(_gridParent.transform.position.x - _expandValue.x / 2, _gridParent.transform.position.y, _gridParent.transform.position.z - _expandValue.y / 2);
        _grid.Reset();
        CreateGrid();

        GridExpanded?.Invoke();
    }

    private void CreateGrid()
    {
        _grid = new Grid(_gridParent,_cellPrefab, new Vector2Int((int)transform.localScale.x, (int)transform.localScale.z), _gridRandomness).Create();

        _availableCells = _grid.Cells.ToList();
        _busyCells.Clear();
    }
}
