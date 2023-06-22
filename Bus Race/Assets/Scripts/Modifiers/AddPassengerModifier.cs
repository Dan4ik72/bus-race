using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AddPassengerModifier : Modifier
{
    [SerializeField] private int _passengersCount = 5;

    private PassengersSpawner _spawner;

    public void Init(PassengersSpawner spawner) => _spawner = spawner;

    protected override void Apply(ModifiersTrigger trigger)
    {

    }
}
