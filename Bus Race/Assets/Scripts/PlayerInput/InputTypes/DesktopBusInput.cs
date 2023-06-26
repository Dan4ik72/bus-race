using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesktopBusInput : PlayerBusInput, IBusInput
{
    public DesktopBusInput(Transform raycastPoint, float busStationIdleTime) : base(raycastPoint, busStationIdleTime) { }
    
    public void Update()
    {
        RaycastBusStation();

        if (IsStayingOnBusStation)
            return;

        if (Input.GetKeyDown(KeyCode.W))
            OnGasPressed();
        if (Input.GetKeyUp(KeyCode.W))
            OnIdlePressed();
    }
}
