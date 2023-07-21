using UnityEngine;

public interface IPassengerSetUp
{
    public void Init(PassengerConfig passengerConfig);

    public void SetTakeBusCellState(Transform place);

    public Transform GetTransform();
}

