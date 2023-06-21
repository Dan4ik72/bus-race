using UnityEngine;

public interface IPassengerSetUp
{
    public IPassengerSetUp Init(BusEntryPointTrigger butEntryPointTrigger);

    public void TakeEmptyBusCell(Cell cell);

    public Transform GetTransform();
}

