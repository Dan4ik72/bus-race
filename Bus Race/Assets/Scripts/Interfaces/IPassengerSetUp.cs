using UnityEngine;

public interface IPassengerSetUp
{
    public void Init(PassengerConfig passengerConfig);

    public void TakeEmptyBusCell(Transform place);

    public Transform GetTransform();
}

