using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BusPassengerZone : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private BusPlaceCell _cellPrefab;
    [SerializeField] private Vector2 _expandValue;

    private Grid _grid;

    private List<Transform> _availablePlaces = new List<Transform>();
    private List<Transform> _busyPlaces = new List<Transform>();

    private float _gridRandomness = 0.1f;

    public event UnityAction GridExpanded;

    private void Start() => CreateGrid();

    public Transform GetAvailablePlace()
    {
        if (_availablePlaces.Count <= 0)
        {
            Expand();
        }

        Transform requestedPlace = _availablePlaces.FirstOrDefault();

        _availablePlaces.Remove(requestedPlace);
        _busyPlaces.Add(requestedPlace);

        return requestedPlace;
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
        _grid = new Grid(_gridParent,_cellPrefab, new Vector2(transform.localScale.x, transform.localScale.z), _gridRandomness).Create();

        _availablePlaces = _grid.Cells.ToList();
        _busyPlaces.Clear();
    }
}
