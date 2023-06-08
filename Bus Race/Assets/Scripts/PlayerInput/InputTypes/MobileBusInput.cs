using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MobileBusInput : IBusInput, IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction Pressed;
    public event UnityAction Unpressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Unpressed?.Invoke();
    }
}
