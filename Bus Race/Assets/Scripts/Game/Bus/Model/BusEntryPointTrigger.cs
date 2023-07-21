using UnityEngine;

public class BusEntryPointTrigger : MonoBehaviour
{
    [SerializeField] private Material _busMaterial;

    private BusPassengers _busPassengers;

    public Material BusMaterial => _busMaterial;

    public void Init(BusPassengers passengersList)
    {
        _busPassengers = passengersList;
    }

    public void EnterBus(IPassengerSetUp passegner)
    {
        _busPassengers.AddPassegner(passegner);
    }
}
