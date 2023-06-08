using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus
{
    private int _startCapacity;

    public Bus(int startCapacity)
    {
        _startCapacity = startCapacity;
    }

    public int StartCapacity => _startCapacity;
}
