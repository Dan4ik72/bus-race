using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPlayerInput
{
    public event UnityAction Pressed;
    public event UnityAction Unpressed;
}
