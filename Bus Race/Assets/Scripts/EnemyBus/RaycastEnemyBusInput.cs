using UnityEngine;
using UnityEngine.Events;

public class RaycastEnemyBusInput : IBusInput
{
    private Transform _raycastPoint;

    private float _raycastDistance = 2f;

    private int _obstacleLayerMask;

    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;

    public RaycastEnemyBusInput(Transform raycastPoint, int obstacleLayerMask)
    {
        _raycastPoint = raycastPoint;
        _obstacleLayerMask = obstacleLayerMask;
    }

    public void RaycastForward()
    {
        Ray ray = new Ray(_raycastPoint.position, new Vector3(1, 0, 0));

        if (Physics.Raycast(ray, _raycastDistance, 1<<_obstacleLayerMask))
        {
            IdlePressed?.Invoke();
            return;
        }
        
        GasPressed?.Invoke();
    }
}

