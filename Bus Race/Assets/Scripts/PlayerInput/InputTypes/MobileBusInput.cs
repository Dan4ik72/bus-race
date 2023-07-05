using UnityEngine;
using UnityEngine.EventSystems;

public class MobileBusInput : PlayerBusInput, IBusInput, IPointerDownHandler, IPointerUpHandler
{
    public MobileBusInput(Transform raycastPoint, BusEntryPointTrigger busEntryPointTrigger,float busStationIdleTime) : base(raycastPoint, busEntryPointTrigger ,busStationIdleTime) { }
    
    public void Update() => RaycastBusStation();

    public void OnPointerDown(PointerEventData eventData)
    {
        if (IsStayingOnBusStation)
            return;

        OnGasPressed();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnIdlePressed();
    }
}
