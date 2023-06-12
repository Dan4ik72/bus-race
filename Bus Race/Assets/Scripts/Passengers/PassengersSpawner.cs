using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersSpawner
{
    private BusEntryPointTrigger _busEntryPointTrigger;

    private PassengerStateMachineSetUp _passengerTemplate;

    private IReadOnlyList<SpawnZone> _spawnZones;

    public PassengersSpawner(BusEntryPointTrigger busEntryPointTrigger, PassengerStateMachineSetUp passegnerTemplate, IReadOnlyList<SpawnZone> spawnZones)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _passengerTemplate = passegnerTemplate;
        _spawnZones = spawnZones;
    }

    public void SpawnAndInitPassegner(Cell cell)
    {
        Object.Instantiate(_passengerTemplate, cell.transform.position, Quaternion.identity).Init(_busEntryPointTrigger);
    }

    public void FillLevel()
    {
        foreach (var spawnZone in _spawnZones)
            FillSpawnZone(spawnZone);
    }

    private void FillSpawnZone(SpawnZone spawnZone)
    { 
        foreach (var spawnPlace in spawnZone.GetSpawnPlaces())
            SpawnAndInitPassegner(spawnPlace);
    }
}
