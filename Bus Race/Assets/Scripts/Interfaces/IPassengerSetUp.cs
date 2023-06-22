using UnityEngine;

public interface IPassengerSetUp
{
    public IPassengerSetUp Init(BusEntryPointTrigger butEntryPointTrigger, PassengerConfig passengerConfig);

    public void TakeEmptyBusCell(Transform place);

    public Transform GetTransform();
}

