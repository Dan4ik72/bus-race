using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IBusInput
{
    public event UnityAction Pressed;
    public event UnityAction Unpressed;
}
