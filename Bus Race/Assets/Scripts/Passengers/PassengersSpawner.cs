using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersSpawner
{
    private BusEntryPointTrigger _busEntryPointTrigger;

    private DefaultPassengerSetUp _DefaultPassengerTemplate;

    private PassengerConfig _defaultPassengerConfig;

    private IReadOnlyList<SpawnZone> _spawnZones;

    public PassengersSpawner(BusEntryPointTrigger busEntryPointTrigger, DefaultPassengerSetUp defaultPassegnerTemplate, PassengerConfig defaultPassengerConfing, IReadOnlyList<SpawnZone> spawnZones)
    {
        _busEntryPointTrigger = busEntryPointTrigger;
        _DefaultPassengerTemplate = defaultPassegnerTemplate;
        _defaultPassengerConfig = defaultPassengerConfing;
        _spawnZones = spawnZones;
    }

    public IPassengerSetUp SpawnAndInitDefaultPassegner(Transform spawnPlace)
    {
        return Object.Instantiate(_DefaultPassengerTemplate, spawnPlace.position, Quaternion.identity).Init(_busEntryPointTrigger, _defaultPassengerConfig);
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
