using UnityEngine;
using UnityEngine.EventSystems;

public class MobileBusInput : PlayerBusInput, IBusInput
{
    public MobileBusInput(Transform raycastPoint, BusEntryPointTrigger busEntryPointTrigger,float busStationIdleTime) : base(raycastPoint, busEntryPointTrigger ,busStationIdleTime) { }

    public void Update()
    {
        RaycastBusStation();

        if (IsStayingOnBusStation)
            return;

        if (Input.GetMouseButton(0))
            OnGasPressed();
        if (Input.GetMouseButtonUp(0))
            OnIdlePressed();
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
