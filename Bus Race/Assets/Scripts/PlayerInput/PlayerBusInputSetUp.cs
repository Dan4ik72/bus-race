using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBusInputSetUp
{
    private BusMover _busMover;

    private BusInputHandler _inputHandler;
    private MobileBusInput _mobileInput;
    private DesktopBusInput _desktopInput;

    private IBusInput _currentInput;

    public PlayerBusInputSetUp(BusMover busMover)
    {
        _busMover = busMover;
    }

    public IBusInput CurrentInput => _currentInput;

    public void Awake()
    {
        _mobileInput = new MobileBusInput();
        _desktopInput = new DesktopBusInput();

        _currentInput = SelectInputType();

        _inputHandler = new BusInputHandler(_currentInput, _busMover);
    }

    public void OnEnable()
    {
        _inputHandler.Enable();
    }

    public void OnDisable()
    {
        _inputHandler.Disable();
    }

    public void Update()
    {
        _desktopInput.Update();
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
