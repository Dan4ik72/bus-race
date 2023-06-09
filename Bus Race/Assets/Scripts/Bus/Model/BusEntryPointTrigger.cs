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

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Passegner>(out Passegner passenger))
        {

        }
    }

    private void OnPassegnerEntered()
    {
        Cell freeCell = _passengerZone.GetAvailableCell();
    }
}
