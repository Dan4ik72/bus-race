using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AddPassengerModifier : Modifier
{
    [SerializeField] private int _passengersCount = 8;

    protected override void Apply(ModifiersCatcher trigger)
    {
        SpawnPassengers(trigger);
    }

    private void SpawnPassengers(ModifiersCatcher trigger)
    {
        for (int i = 0; i < _passengersCount; i++)
        {
            var spawnedPassenger = PassengerSpawner.SpawnDefaultPassenger(trigger.PassengerCollector.PassengersParent.transform, trigger.PassengerCollector.PassengersParent);
            spawnedPassenger.SetGoingToBusTtate(trigger.BusEntryPointTrigger);
        }
    }
}
