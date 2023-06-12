using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Grid
{
    private Cell _cellPrefab;
    private Transform _parent;

    private Vector2Int _capacity = new Vector2Int(2,4);

    private List<Cell> _cells;

    private float _cellPositionRandomness = 0;

    public Grid(Transform cellParent, Cell cellPrefab, Vector2Int gridCapacity, float cellPositionRandomness = 0)
    {
        _cellPrefab = cellPrefab;
        _parent = cellParent;
        _capacity = gridCapacity;

        _cells = new List<Cell>();

        _capacity = _capacity.x < 0 || _capacity.y < 0 ? _capacity = Vector2Int.zero : gridCapacity;

        _cellPositionRandomness = Mathf.Clamp(cellPositionRandomness, 0, 2);
    }

    public IReadOnlyList<Cell> Cells => _cells;
        
    public Grid Create()
    {
        for(float currentXPosition = _parent.position.x; currentXPosition <= _capacity.x + _parent.position.x;)
        {
            for(float currentYPosition = _parent.position.z; currentYPosition <= _capacity.y + _parent.position.z;)
            {
                var cellPosition = new Vector3(currentXPosition + Random.Range(-_cellPositionRandomness, _cellPositionRandomness)
                    , _parent.position.y,
                    currentYPosition + Random.Range(-_cellPositionRandomness, _cellPositionRandomness));

                CreateCell(cellPosition);

                currentYPosition += Cell.Height;
            }

            currentXPosition += Cell.Width;
        }

        return this;
    }
    
    public void Reset()
    {
        foreach(Cell cell in _cells)
            Object.Destroy(cell.gameObject);

        _cells.Clear();
    }

    private Cell CreateCell(Vector3 position)
    {
        var cellPosition = new Vector3(position.x, position.y, position.z);

        Cell newCell = Object.Instantiate(_cellPrefab, cellPosition, Quaternion.identity, _parent);

        _cells.Add(newCell);

        return newCell;
    }
}
