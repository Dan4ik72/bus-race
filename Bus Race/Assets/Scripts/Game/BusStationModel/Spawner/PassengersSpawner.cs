using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersSpawner
{
    private DefaultPassengerSetUp _defaultPassengerTemplate;
    private PassengerConfig _defaultPassengerConfig;

    public PassengersSpawner(DefaultPassengerSetUp defaultPassegnerTemplate, PassengerConfig defaultPassengerConfig)
    {
        _defaultPassengerTemplate = defaultPassegnerTemplate;
        _defaultPassengerConfig = defaultPassengerConfig;
    }

    public DefaultPassengerSetUp SpawnDefaultPassenger(Transform spawnPlace, Transform parent = null)
    {
        var created = Object.Instantiate(_defaultPassengerTemplate, spawnPlace.position, Quaternion.identity, parent);
        created.Init(_defaultPassengerConfig);
        return created;
    }
}
