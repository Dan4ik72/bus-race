using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesktopInput : IPlayerInput
{
    public event UnityAction Pressed;
    public event UnityAction Unpressed;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Pressed();

        if (Input.GetKeyUp(KeyCode.W))
            Unpressed?.Invoke();
    }
}
