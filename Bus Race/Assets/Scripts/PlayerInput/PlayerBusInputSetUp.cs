using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBusInputSetUp
{
    private BusMover _busMover;

    private BusInputHandler _inputHandler;
    private MobileBusInput _mobileInput;
    private DesktopBusInput _desktopInput;
    private GameEndingInput _gameEndingInput;

    private IBusInput _currentInput;

    public PlayerBusInputSetUp(BusMover busMover, BusEntryPointTrigger busEntryPointTrigger,Transform raycastPoint, BusConfig config)
    {
        _busMover = busMover;

        _mobileInput = new MobileBusInput(raycastPoint, busEntryPointTrigger, config.BusStationIdleTime);
        _desktopInput = new DesktopBusInput(raycastPoint, busEntryPointTrigger, config.BusStationIdleTime);

        _currentInput = SelectInputType();

        _inputHandler = new BusInputHandler(_currentInput, _busMover);
    }

    public IBusInput CurrentInput => _currentInput;

    public void SetGameEndingInputType()
    {
        _gameEndingInput = new GameEndingInput();

        _currentInput = _gameEndingInput;

        _inputHandler.SetNewInput(_gameEndingInput);
        _gameEndingInput.Enter();
    }

    public void Enable()
    {
        _inputHandler.Enable();
    }

    public void Disable()
    {
        _inputHandler.Disable();
    }

    public void Update()
    {
        _currentInput.Update();
    }

    private IBusInput SelectInputType()
    {
        //after import YandexSDK,it have to be replaced with the sdk's method
        InputType inputType = InputType.Desktop;

        switch (inputType)
        {
            case InputType.Mobile:
                return _mobileInput;

            case InputType.Desktop:
                return _desktopInput;

            default:
                return _mobileInput;
        }
    }
}

public enum InputType
{
    Mobile,
    Desktop
}
