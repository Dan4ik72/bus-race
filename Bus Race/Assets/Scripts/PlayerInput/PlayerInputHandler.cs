using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler 
{
    private IPlayerInput _playerInput;

    private BusMover _busMover;

    public PlayerInputHandler(IPlayerInput playerInput, BusMover busMover)
    {
        _playerInput = playerInput;
        _busMover = busMover;
    }

    public void SetNewInput(IPlayerInput newInput)
    {
        if (newInput == null)
            return;

        _playerInput = newInput;
    }

    public void Enable()
    {
        _playerInput.Pressed += OnPressed;
        _playerInput.Unpressed += OnUnpressed;
    }

    public void Disable()
    {
        _playerInput.Pressed -= OnPressed;
        _playerInput.Unpressed -= OnUnpressed;
    }

    private void OnPressed()
    {
        _busMover.SetGasSpeed();
    }

    private void OnUnpressed()
    {
        _busMover.SetIdleSpeed();
    }
}
