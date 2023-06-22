using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerCompositeRoot : CompositeRoot
{
    [SerializeField] private BusCompositeRoot _busCompositeRoot;
    [SerializeField] private List<SpawnZone> _spawnZones;
    [SerializeField] private DefaultPassengerSetUp _passengerPrefab;
    [SerializeField] private PassengerConfig _defaultPassengerConfig;

    private PassengersSpawner _spawner;
    private BusPassengers _busPassegners;

    public PassengersSpawner Spawner => _spawner;

    public override void Compose()
    {
        _spawner = new PassengersSpawner(_busCompositeRoot.EntryPointTrigger, _passengerPrefab, _defaultPassengerConfig ,_spawnZones);
    }

    private void Start()
    {
        _spawner.FillLevel();
    }
}
