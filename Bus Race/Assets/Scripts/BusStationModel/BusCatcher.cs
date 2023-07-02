using System.Collections;
using UnityEngine;

public class BusCatcher : MonoBehaviour
{
    private float _goingToBusDelay;

    private BusStationPassengers _passengers;

    public void Init(BusStationPassengers passengers, float goingToBusDelay)
    {
        _passengers = passengers;
        _goingToBusDelay = goingToBusDelay;

        _passengers.BusStationEmpty += Disable;
    }

    public void OnBusArrived(BusEntryPointTrigger busEntryPointTrigger)
    {
        StartCoroutine(SetBusEmptyPointTriggerToPassengersDelayed(busEntryPointTrigger));
    }

    private void SetBusEmptyPointTriggerToPassengers(BusEntryPointTrigger busEntryPointTrigger)
    {
        _passengers.SetBusEmptyPointTrigger(busEntryPointTrigger);
    }

    private IEnumerator SetBusEmptyPointTriggerToPassengersDelayed(BusEntryPointTrigger busEntryPointTrigger)
    {
        yield return new WaitForSecondsRealtime(_goingToBusDelay);

        SetBusEmptyPointTriggerToPassengers(busEntryPointTrigger);
    }

    private void Disable()
    {
        _passengers.BusStationEmpty -= Disable;

        gameObject.SetActive(false);

        enabled = false;
    }
}
