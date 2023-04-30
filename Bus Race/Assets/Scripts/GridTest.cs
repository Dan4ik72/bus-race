using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    [SerializeField] private Cell _cellTemplate;

    [SerializeField] private Transform _cellParent;

    [SerializeField] private int _cellsCount;

    private Vector2Int _gridCapacity => _cellsCount * _cellTemplate.Size;

    private List<Cell> _cells = new List<Cell>();

    private void Start()
    {
        for(float x = _cellParent.position.x; x < _gridCapacity.x + _cellParent.position.x;)
        {
            for (float y = _cellParent.position.z; y < _gridCapacity.y + _cellParent.position.z;)
            {

                Cell createdCell = SpawnCell(new Vector3(x, 0, y));

                _cells.Add(createdCell);

                y += _cellTemplate.Size.y;
            }

            x += _cellTemplate.Size.x;
        }
    }

    private Cell SpawnCell(Vector3 position)
    {
        return Instantiate(_cellTemplate, position, Quaternion.identity, _cellParent);
    }
}
