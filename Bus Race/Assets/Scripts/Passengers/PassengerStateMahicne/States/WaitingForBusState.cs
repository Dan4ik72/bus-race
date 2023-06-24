using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForBusState : BusInteractionState
{
    private float _maxDistanceToBusTrigger;

    private DefaultPassengerSetUp _passenger;

    public WaitingForBusState(StateMachine stateMachine, DefaultPassengerSetUp passenger, float maxDistanceToBusTrigger) : base(stateMachine, passenger.transform)
    {
        _maxDistanceToBusTrigger = maxDistanceToBusTrigger;
        _passenger = passenger;
    }

    public override void Update()
    {
        //BusEntryPointTrigger busEntryPointTrigger = TryGetBusEntryPointTrigger();

        /*if (busEntryPointTrigger != null)
        {
            _passenger.SetBusEmptyPointTrigger(busEntryPointTrigger);
            StateMachine.SetState<GoingToBusState>();
        }*/

        //if (Vector3.Distance(PassengerTransform.position, BusEntryPointTrigger.transform.position) < _maxDistanceToBusTrigger)
        //    StateMachine.SetState<GoingToBusState>();
    }

    private BusEntryPointTrigger TryGetBusEntryPointTrigger()
    {
        Collider[] hitColliders = Physics.OverlapSphere(PassengerTransform.position, _maxDistanceToBusTrigger, 1<<3);

        if (hitColliders.Length <= 0)
            return null;

        foreach(var hit in hitColliders)
        {
            if (hit.TryGetComponent(out BusEntryPointTrigger busEntryPointTrigger))
            {
                return busEntryPointTrigger;
            }
        }

        return null;
    }
}
