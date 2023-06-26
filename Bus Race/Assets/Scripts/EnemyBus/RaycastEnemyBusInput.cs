﻿using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class RaycastEnemyBusInput : IBusInput
{
    private Transform _raycastPoint;

    private float _raycastDistance = 2f;

    private int _obstacleLayer;
    private int _busStationLayer = 9;

    private float _busStationIdleTime;

    private bool _isStayingOnBusStation = false;

    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;

    public RaycastEnemyBusInput(Transform raycastPoint, float busStationIdleTime ,int obstacleLayerMask)
    {
        _raycastPoint = raycastPoint;
        _obstacleLayer = obstacleLayerMask;
        _busStationIdleTime = busStationIdleTime;
    }

    public void Move()
    {
        if(_isStayingOnBusStation == false)
        {
            RaycastForward();
            RaycastBusStation();

            return;
        }

        IdlePressed?.Invoke();
    }

    private void RaycastForward()
    {
        Ray ray = new Ray(_raycastPoint.position, new Vector3(1, 0, 0));

        if (Physics.Raycast(ray, _raycastDistance, 1<<_obstacleLayer))
        {
            IdlePressed?.Invoke();
            return;
        }
        
        GasPressed?.Invoke();
    }

    private void RaycastBusStation()
    {
        Ray ray = new Ray(_raycastPoint.position, new Vector3(0, -1, 0));
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit ,_raycastDistance, 1<<_busStationLayer))
        {
            Coroutines.StartRoutine(StartBusStationTimer());   
        }
    }

    private IEnumerator StartBusStationTimer()
    {
        _isStayingOnBusStation = true;

        yield return new WaitForSecondsRealtime(_busStationIdleTime);

        _isStayingOnBusStation = false;
    }
}

