using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSetUp : MonoBehaviour
{
    [SerializeField] private BusMover _busMover;

    private PlayerInputHandler _inputHandler;

    private MobileInput _mobileInput;
    private DesktopInput _desktopInput;

    private void Awake()
    {
        _mobileInput = new MobileInput();
        _desktopInput = new DesktopInput();

        IPlayerInput currentInputType = SelectInputType();

        _inputHandler = new PlayerInputHandler(currentInputType, _busMover);
    }

    private void OnEnable()
    {
        _inputHandler.Enable();
    }

    private void OnDisable()
    {
        _inputHandler.Disable();
    }

    private void Update()
    {
        _desktopInput.Update();
    }

    private IPlayerInput SelectInputType()
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
