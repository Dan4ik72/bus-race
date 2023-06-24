using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BusCatcher : MonoBehaviour
{
    [SerializeField] private int _busEntryPointTriggerLayer;

    private IReadOnlyList<DefaultPassengerSetUp> _passengers = new List<DefaultPassengerSetUp>();

    private float _maxDistanceToBus = 5f;

    private Collider[] _overlapHitColliders;

    public void Init(PassengerSpawnZone passengerSpawnZone)
    {
        _passengers = passengerSpawnZone.Passengers;
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
                SetBusEmptyPointTriggerToPassengers(busEntryPointTrigger);
                gameObject.SetActive(false);
            }
        }
    }

    private bool TryGetBusEntryPointTrigger(Collider collider, out BusEntryPointTrigger busEntryPointTrigger)
    {
        return collider.TryGetComponent(out busEntryPointTrigger);
    }

    private void SetBusEmptyPointTriggerToPassengers(BusEntryPointTrigger busEntryPointTrigger)
    {
        foreach (var passenger in _passengers)
            passenger.SetBusEmptyPointTrigger(busEntryPointTrigger);
    }
}
