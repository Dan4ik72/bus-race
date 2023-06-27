using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PassengerSpawnZone : MonoBehaviour
{
    [SerializeField] private SpawnPlaceCell _cellPrefab;
    [SerializeField] private Transform _cellsParent;

    [SerializeField] private Vector2 _gridSize;

    private float _passengerDefaultYRotation = -90;

    private Grid _grid;

    private PassengersSpawner _spawner;
    private PassengerConfig _passengerConfig;

    private List<DefaultPassengerSetUp> _passengers = new List<DefaultPassengerSetUp>();

    public void Init(PassengersSpawner spawner, PassengerConfig passengerConfig)
    {
        _spawner = spawner;
        _passengerConfig = passengerConfig;

        CreateGrid();
        SpawnPassengers();
    }

    public IReadOnlyList<DefaultPassengerSetUp> Passengers => _passengers;

    private void CreateGrid()
    {
        _grid = new Grid(_cellsParent, _cellPrefab, _gridSize, 0.25f).Create();
    }

    private void SpawnPassengers()
    {
        foreach(var spawnPlace in _grid.Cells)
        {
            DefaultPassengerSetUp createdPassenger = _spawner.SpawnDefaultPassenger(spawnPlace,_cellsParent);
            createdPassenger.Init(_passengerConfig);
            createdPassenger.transform.rotation = Quaternion.Euler(createdPassenger.transform.rotation.x, _passengerDefaultYRotation, createdPassenger.transform.rotation.z);
            _passengers.Add(createdPassenger);
        }
    }
}
