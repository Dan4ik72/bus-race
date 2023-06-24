using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerCompositeRoot : CompositeRoot
{
    [SerializeField] private BusCompositeRoot _busCompositeRoot;
    [SerializeField] private DefaultPassengerSetUp _passengerPrefab;
    [SerializeField] private PassengerConfig _defaultPassengerConfig;

    private PassengersSpawner _spawner;

    public PassengersSpawner Spawner => _spawner;

    public override void Compose()
    {
        _spawner = new PassengersSpawner(_passengerPrefab);
    }
}
