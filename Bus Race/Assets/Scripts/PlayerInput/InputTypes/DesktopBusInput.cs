using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesktopBusInput : IBusInput
{
    public event UnityAction Pressed;
    public event UnityAction Unpressed;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Pressed?.Invoke();

        if (Input.GetKeyUp(KeyCode.W))
            Unpressed?.Invoke();
    }
}
