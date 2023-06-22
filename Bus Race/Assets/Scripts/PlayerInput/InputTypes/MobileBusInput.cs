using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MobileBusInput : IBusInput, IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        GasPressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IdlePressed?.Invoke();
    }
}
