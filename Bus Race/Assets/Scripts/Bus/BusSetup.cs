using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSetup : MonoBehaviour
{
    [Header("BusConfig")]
    [Space, SerializeField] private BusConfig _config;

    [SerializeField] private BusMover _mover;

    private Bus _model;

    private void Awake()
    {
        _model = new Bus(_config.StartCapacity);
    }
}
