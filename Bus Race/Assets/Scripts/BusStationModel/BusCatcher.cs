using System.Collections;
using UnityEngine;

public class BusCatcher : MonoBehaviour
{
    [SerializeField] private int _busEntryPointTriggerLayer;
    [SerializeField] private Transform _busStationStopTrigger;

    private float _maxDistanceToBus = 5f;
    private float _cooldownToArrivedBus = 0.8f;

    private Collider[] _overlapHitColliders;

    private BusStationPassengers _passengers;

    public void Init(BusStationPassengers passengers)
    {
        _passengers = passengers;

        _passengers.BusStationEmpty += Disable;
    }

    private void Update()
    {
        _overlapHitColliders = Physics.OverlapSphere(transform.position, _maxDistanceToBus, 1<<_busEntryPointTriggerLayer);

        if (_overlapHitColliders.Length <= 0)
            return;

        foreach(var collider in _overlapHitColliders)
        {
            if(TryGetBusEntryPointTrigger(collider, out BusEntryPointTrigger busEntryPointTrigger))
            {
                Coroutines.StartRoutine(SetBusEmptyPointTriggerToPassengersDelayed(busEntryPointTrigger));
                return;
            }
        }
    }

    private bool TryGetBusEntryPointTrigger(Collider collider, out BusEntryPointTrigger busEntryPointTrigger)
    {
        return collider.TryGetComponent(out busEntryPointTrigger);
    }

    private void SetBusEmptyPointTriggerToPassengers(BusEntryPointTrigger busEntryPointTrigger)
    {
        _passengers.SetBusEmptyPointTrigger(busEntryPointTrigger);
    }

    private IEnumerator SetBusEmptyPointTriggerToPassengersDelayed(BusEntryPointTrigger busEntryPointTrigger)
    {
        yield return new WaitForSecondsRealtime(_cooldownToArrivedBus);

        SetBusEmptyPointTriggerToPassengers(busEntryPointTrigger);
    }

    private void Disable()
    {
        _passengers.BusStationEmpty -= Disable;

        _busStationStopTrigger.gameObject.SetActive(false);

        enabled = false;
    }
}
