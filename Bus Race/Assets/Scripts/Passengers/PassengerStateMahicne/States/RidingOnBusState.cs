using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingOnBusState : BusInteractionState
{
    private float _yPassengerRotation = 90;

    private IMoveHandler _moveHandler;

    public RidingOnBusState(StateMachine stateMachine, Transform passengerTransform, IMoveHandler moveHandler) : base(stateMachine, passengerTransform) 
    {
        _moveHandler = moveHandler;
    }

    public override void Enter()
    {
        Coroutines.StartRoutine(SetPassengerBusRotation());
    }

    private IEnumerator SetPassengerBusRotation()
    {
        var targetLocalEulerAngules = new Vector3(PassengerTransform.localEulerAngles.x, _yPassengerRotation, PassengerTransform.localEulerAngles.z);

        while (PassengerTransform.localEulerAngles.y - targetLocalEulerAngules.y > Mathf.Abs(5))
        {
            _moveHandler.Rotate((targetLocalEulerAngules), 40);

            yield return null;
        }
    }
}
