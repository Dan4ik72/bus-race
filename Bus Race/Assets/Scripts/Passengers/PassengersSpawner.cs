using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersSpawner
{
    private BusEntryPointTrigger _busEntryPointTrigger;

    private DefaultPassengerSetUp _DefaultPassengerTemplate;

    private IReadOnlyList<SpawnZone> _spawnZones;

    public PassengersSpawner(BusEntryPointTrigger busEntryPointTrigger, DefaultPassengerSetUp defaultPassegnerTemplate, IReadOnlyList<SpawnZone> spawnZones)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _DefaultPassengerTemplate = defaultPassegnerTemplate;
        _spawnZones = spawnZones;
    }

    public IPassengerSetUp SpawnAndInitDefaultPassegner(Cell cell)
    {
        return Object.Instantiate(_DefaultPassengerTemplate, cell.transform.position, Quaternion.identity).Init(_busEntryPointTrigger);
    }

    public void FillLevel()
    {
        foreach (var spawnZone in _spawnZones)
            FillSpawnZone(spawnZone);
    }

    private void FillSpawnZone(SpawnZone spawnZone)
    { 
        foreach (var spawnPlace in spawnZone.GetSpawnPlaces())
            SpawnAndInitDefaultPassegner(spawnPlace);
    }
}
