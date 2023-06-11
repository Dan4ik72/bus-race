using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BusPassengers
{
    private Dictionary<PassengerStateMachineSetUp, Cell> _passegners = new Dictionary<PassengerStateMachineSetUp, Cell>();

    private Transform _passengersParent;

    public event UnityAction PassegnerAdded;

    public BusPassengers(Transform passengersParent) => _passengersParent = passengersParent;

    public void AddPassegner(PassengerStateMachineSetUp passenger, Cell takenCell)
    {
        if (_passegners.ContainsKey(passenger))
            return;

        _passegners.Add(passenger, takenCell);

        passenger.transform.parent = _passengersParent;
        takenCell.SetBusy(true);

        PassegnerAdded?.Invoke();
    }
}
