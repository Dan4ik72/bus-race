using UnityEngine;
using UnityEngine.EventSystems;

public class MobileBusInput : PlayerBusInput, IBusInput
{
    public MobileBusInput(Transform raycastPoint, BusEntryPointTrigger busEntryPointTrigger,float busStationIdleTime) : base(raycastPoint, busEntryPointTrigger ,busStationIdleTime) { }

    public void Update()
    {
        RaycastBusStation();

        if (Input.GetMouseButtonDown(0))
            SetGasPressed();
        else
            SetGasUnpressed();
    }

    private void SetGasPressed()
    {
        if (IsStayingOnBusStation)
            return;

        OnGasPressed();
    }

    private void SetGasUnpressed()
    {
        OnIdlePressed();
    }
}
