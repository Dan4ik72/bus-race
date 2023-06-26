using UnityEngine;
using UnityEngine.EventSystems;

public class MobileBusInput : PlayerBusInput, IPointerDownHandler, IPointerUpHandler
{
    public MobileBusInput(Transform raycastPoint, float busStationIdleTime) : base(raycastPoint, busStationIdleTime) { }
    
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
