using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesktopBusInput : IBusInput
{
    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            GasPressed?.Invoke();

        if (Input.GetKeyUp(KeyCode.W))
            IdlePressed?.Invoke();
    }
}
