using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class PassengerZone : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;

    [SerializeField] private Vector2Int _expandValue;

    private Grid _grid;

    private List<Cell> _availableCells = new List<Cell>();
    private List<Cell> _busyCells = new List<Cell>();

    private void Start()
    {
        CreateGrid();
    }

    public Cell GetAvailableCell()
    {
        if (_availableCells.Count <= 0)
            Expand();

        Cell requestedCell = _availableCells.FirstOrDefault();

        _availableCells.Remove(requestedCell);
        _busyCells.Add(requestedCell);

        return requestedCell;
    }

    private void Expand()
    {
        transform.localScale = new Vector3(transform.localScale.x + _expandValue.x,
            transform.localScale.y, transform.localScale.z + _expandValue.y);

        CreateGrid();
    }

    private void CreateGrid()
    {
        _grid = new Grid(_gridParent, new Vector2Int((int)transform.localScale.x, (int)transform.localScale.z));

        _grid.Create();

        _availableCells = _grid.Cells.ToList();
        _busyCells.Clear();
    }
}
