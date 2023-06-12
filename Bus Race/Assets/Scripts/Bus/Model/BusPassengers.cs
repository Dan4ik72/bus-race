using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BusPassengers
{
    private List<PassengerStateMachineSetUp> _passengers = new List<PassengerStateMachineSetUp>();

    private Transform _passengersParent;
    private BusPassengerZone _passengerZone;

    public event UnityAction PassegnerAdded;

    public BusPassengers(Transform passengersParent, BusPassengerZone passegnerZone)
    {
        _passengersParent = passengersParent;
        _passengerZone = passegnerZone;

        _passengerZone.GridExpanded += OnPassegnerZoneExpanded;
    } 

    public void AddPassegner(PassengerStateMachineSetUp passenger)
    {
        Cell availableCell = _passengerZone.GetAvailableCell();

        passenger.transform.parent = _passengersParent;
        passenger.SetTakeEmptyBusCellState(availableCell);

        _passengers.Add(passenger);

        PassegnerAdded?.Invoke();
    }

    private void OnPassegnerZoneExpanded()
    {
        _passengers.ForEach(passenger => passenger.SetTakeEmptyBusCellState(_passengerZone.GetAvailableCell()));
    }
}
