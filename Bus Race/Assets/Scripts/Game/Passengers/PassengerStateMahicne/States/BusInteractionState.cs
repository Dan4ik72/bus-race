using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BusInteractionState : State
{
    private Transform _passengerTransform;

    public BusInteractionState(StateMachine stateMachine, Transform passengerTransform) : base(stateMachine)
    {
        _passengerTransform = passengerTransform;
    }

    protected Transform PassengerTransform => _passengerTransform;
}
