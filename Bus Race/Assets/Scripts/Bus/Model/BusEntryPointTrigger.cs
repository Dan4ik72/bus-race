using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusEntryPointTrigger : MonoBehaviour
{
    private BusPassengerZone _passengerZone;

    public void Init(BusPassengerZone passengerZone)
    {
        _passengerZone = passengerZone;
    }

    public Cell GetAvailableCell()
    {
        return _passengerZone.GetAvailableCell();
    }
}
