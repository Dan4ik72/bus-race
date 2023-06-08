using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PassengerZone : MonoBehaviour
{
    [SerializeField] private GameObject _cellPreview;

    [SerializeField] private Transform _gridParent;

    [SerializeField] private Grid _grid;

    private List<GameObject> _cellPreviews = new List<GameObject>();

    private List<Cell> _availableCells = new List<Cell>();
    private List<Cell> _busyCells = new List<Cell>(); 

    private void Start()
    {
        _grid = new Grid(_gridParent, new Vector2Int((int)transform.localScale.x, (int)transform.localScale.z));

        _grid.Create();

        _availableCells = _grid.Cells.ToList();
        SpawnGridPreview();
    }

    private void OnGridParentScaleChagned()
    {
        DeleteGridPreviews();
        _grid = new Grid(_gridParent, new Vector2Int((int)transform.localScale.x, (int)transform.localScale.z), 0.2f);
        _grid.Create();
        SpawnGridPreview();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y,transform.localScale.z + 1);
            _gridParent.position += new Vector3(-0.5f, 0, -0.5f);
            OnGridParentScaleChagned();
        }
    }

    private void SpawnGridPreview()
    {
        foreach (var cell in _grid.Cells)
            _cellPreviews.Add(Instantiate(_cellPreview, cell.Position, Quaternion.identity, _gridParent));
    }

    private void DeleteGridPreviews()
    {
        foreach (var preview in _cellPreviews)
            Destroy(preview);

        _cellPreviews.Clear();
    }
}
