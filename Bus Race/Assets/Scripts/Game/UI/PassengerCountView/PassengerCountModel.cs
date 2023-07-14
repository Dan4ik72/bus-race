using UnityEngine.Events;

public class PassengerCountModel
{
    private BusPassengers _passengers;

    private int _passengerCount = 0;

    public event UnityAction PassengerCountChanged;

    public PassengerCountModel(BusPassengers busPassengers)
    {
        _passengers = busPassengers;

        _passengers.PassegnerAdded += UpdateCount;
    }

    public int PassengerCount => _passengerCount;

    private void UpdateCount()
    {
        _passengerCount++;

        PassengerCountChanged?.Invoke();
    }
}

