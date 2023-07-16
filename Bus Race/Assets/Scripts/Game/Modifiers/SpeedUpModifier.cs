using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpModifier : Modifier
{
    private float _speedBoost = 10f;

    protected override void Apply(ModifiersCatcher trigger)
    {
        SpeedUpBus(trigger.BusMover);
    }

    private void SpeedUpBus(BusMover busMover)
    {
        busMover.SetGasSpeed(busMover.GasSpeed + _speedBoost);
    }
}
