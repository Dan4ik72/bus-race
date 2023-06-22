using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private ICell _cellPrefab;
    private Transform _parent;

    private Vector2 _capacity = new Vector2Int(2,4);

    private List<Transform> _cells;

    private float _cellPositionRandomness = 0;

    public Grid(Transform cellParent, ICell cellPrefab, Vector2 gridCapacity, float cellPositionRandomness = 0)
    {
        _cellPrefab = cellPrefab;
        _parent = cellParent;
        _capacity = gridCapacity;

        _cells = new List<Transform>();

        _capacity = _capacity.x < 0 || _capacity.y < 0 ? _capacity = Vector2.zero : gridCapacity;

        _cellPositionRandomness = Mathf.Clamp(cellPositionRandomness, 0, 1);
    }

    public IReadOnlyList<Transform> Cells => _cells;
    public Vector2 Capacity => _capacity;
        
    public Grid Create()
    {
        for(float currentXPosition = _parent.position.x; currentXPosition <= _capacity.x + _parent.position.x;)
        {
            for(float currentYPosition = _parent.position.z; currentYPosition <= _capacity.y + _parent.position.z;)
            {
                var cellPosition = new Vector3(currentXPosition + Random.Range(-_cellPositionRandomness, _cellPositionRandomness)
                    , _parent.position.y,
                    currentYPosition + Random.Range(-_cellPositionRandomness, _cellPositionRandomness));

                CreateCellTransform(cellPosition);

                currentYPosition += _cellPrefab.Heigh;
            }

            currentXPosition += _cellPrefab.Width;
        }

        return this;
    }
    
    public void Reset()
    {
        foreach(Transform cell in _cells)
            Object.Destroy(cell.gameObject);

        _cells.Clear();
    }

    private Transform CreateCellTransform(Vector3 position)
    {
        var cellPosition = new Vector3(position.x, position.y, position.z);

        Transform newCell = Object.Instantiate(_cellPrefab.GetTransform(), cellPosition, Quaternion.identity, _parent);

        _cells.Add(newCell);

        return newCell;
    }
}
