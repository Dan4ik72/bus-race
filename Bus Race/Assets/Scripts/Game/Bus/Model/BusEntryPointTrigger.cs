using UnityEngine;

public class BusEntryPointTrigger : MonoBehaviour
{
    private BusPassengers _busPassengers;

    public void Init(BusPassengers passengersList)
    {
        _busPassengers = passengersList;
    }

    public void EnterBus(IPassengerSetUp passegner)
    {
        _busPassengers.AddPassegner(passegner);
    }
}
