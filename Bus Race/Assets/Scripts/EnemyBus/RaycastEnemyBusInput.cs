using UnityEngine;
using UnityEngine.Events;

public class RaycastEnemyBusInput : IBusInput
{
    private Transform _raycastPoint;

    private float _raycastDistance;

    private int _obstacleLayerMask;

    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;

    public RaycastEnemyBusInput(Transform raycastPoint, int obstacleLayerMask)
    {
        _raycastPoint = raycastPoint;
        _raycastDistance = obstacleLayerMask;
    }

    public void RaycastForward()
    {
        RaycastHit hit;

        if(Physics.Raycast(_raycastPoint.position, _raycastPoint.TransformDirection(Vector3.forward), out hit, _raycastDistance, _obstacleLayerMask))
        {
            IdlePressed?.Invoke();
            return;
        }

        GasPressed?.Invoke();
    }
}

