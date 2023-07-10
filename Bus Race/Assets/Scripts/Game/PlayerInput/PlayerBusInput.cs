using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerBusInput
{
    private BusEntryPointTrigger _busEntryPointTrigger;

    private bool _isStayingOnBusStation = false;

    private Transform _raycastPoint;
    private float _raycastDistance = 2f;
    private float _busStationIdleTime;
    private int _busStationLayer = 9;

    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;

    public PlayerBusInput(Transform raycastPoint, BusEntryPointTrigger busEntryPointTrigger, float busStationIdleTime)
    {
        _raycastPoint = raycastPoint;
        _busEntryPointTrigger = busEntryPointTrigger;
        _busStationIdleTime = busStationIdleTime;
    }

    protected bool IsStayingOnBusStation => _isStayingOnBusStation;

    protected void RaycastBusStation()
    {
        Ray ray = new Ray(_raycastPoint.position, new Vector3(0, -1, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance, 1 << _busStationLayer))
        {
            if (hit.collider.TryGetComponent(out BusCatcher busCatcher))
                busCatcher.OnBusArrived(_busEntryPointTrigger);

            Coroutines.StartRoutine(StartBusStationTimer());
        }
    }

    protected void OnGasPressed()
    {
        GasPressed?.Invoke();
    }

    protected void OnIdlePressed()
    {
        IdlePressed?.Invoke();
    }

    private IEnumerator StartBusStationTimer()
    {
        _isStayingOnBusStation = true;

        OnIdlePressed();

        yield return new WaitForSecondsRealtime(_busStationIdleTime);

        _isStayingOnBusStation = false;
    }
}
