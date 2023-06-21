using UnityEngine;

public class BusEntryPointTrigger : MonoBehaviour
{
    private BusPassengers _busPassengers;

    public void Init(BusPassengers passengersList)
    {
        _busPassengers = passengersList;
    }

    public void OnPassengerEntered(IPassengerSetUp passegner)
    {
        _busPassengers.AddPassegner(passegner);
    }
}
