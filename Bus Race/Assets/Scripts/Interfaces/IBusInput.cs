using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IBusInput
{
    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;

    void Update();
}