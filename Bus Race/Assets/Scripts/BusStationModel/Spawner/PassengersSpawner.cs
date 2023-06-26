using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersSpawner
{
    private DefaultPassengerSetUp _defaultPassengerTemplate;

    public PassengersSpawner(DefaultPassengerSetUp defaultPassegnerTemplate)
    {
        _defaultPassengerTemplate = defaultPassegnerTemplate;
    }

    public DefaultPassengerSetUp SpawnDefaultPassenger(Transform spawnPlace, Transform parent = null)
    {
        return Object.Instantiate(_defaultPassengerTemplate, spawnPlace.position, Quaternion.identity, parent);
    }
}
