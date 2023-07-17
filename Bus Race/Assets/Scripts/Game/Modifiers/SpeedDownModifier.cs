using UnityEngine;

public class SpeedDownModifier : Modifier
{
    [SerializeField] private float _speedDownValue = 10f;

    protected override void Apply(ModifiersCatcher trigger)
    {
        SpeedDownBus(trigger.BusMover);
    }

    private void SpeedDownBus(BusMover busMover)
    {
        busMover.SetGasSpeed(busMover.GasSpeed - _speedDownValue);
    }
}
