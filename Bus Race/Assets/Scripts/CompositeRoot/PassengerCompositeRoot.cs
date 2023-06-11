using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerCompositeRoot : CompositeRoot
{
    [SerializeField] private BusCompositeRoot _busCompositeRoot;
    [SerializeField] private List<SpawnZone> _spawnZones;
    [SerializeField] private PassengerStateMachineSetUp _passengerPrefab;

    private PassengersSpawner _spawner;

    public PassengersSpawner Spawner => _spawner;

    public override void Compose()
    {
        _spawner = new PassengersSpawner(_busCompositeRoot.EntryPointTrigger, _passengerPrefab, _spawnZones);
    }

    private void Start()
    {
        _spawner.FillLevel();
    }
}
