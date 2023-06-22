using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusInputHandler 
{
    private IBusInput _busInput;

    private BusMover _busMover;

    public BusInputHandler(IBusInput busInput, BusMover busMover)
    {
        _busInput = busInput;
        _busMover = busMover;
    }

    public void SetNewInput(IBusInput newInput)
    {
        if (newInput == null)
            return;

        Disable();

        _busInput = newInput;

        Enable();
    }

    public void Enable()
    {
        _busInput.GasPressed += OnGas;
        _busInput.IdlePressed += OnIdle;
    }

    public void Disable()
    {
        _busInput.GasPressed -= OnGas;
        _busInput.IdlePressed -= OnIdle;
    }

    private void OnGas()
    {
        _busMover.SetGasSpeed();
    }

    private void OnIdle()
    {
        _busMover.SetIdleSpeed();
    }
}
