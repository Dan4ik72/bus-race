using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BusPassengers
{
    private List<IPassengerSetUp> _passengers = new List<IPassengerSetUp>();

    private Transform _passengersParent;
    private BusPassengerZone _passengerZone;

    public event UnityAction PassegnerAdded;

    public BusPassengers(Transform passengersParent, BusPassengerZone passegnerZone)
    {
        _passengersParent = passengersParent;
        _passengerZone = passegnerZone;

        _passengerZone.GridExpanded += OnPassegnerZoneExpanded;
    } 

    public void AddPassegner(IPassengerSetUp passenger)
    {
        Transform availablePlace = _passengerZone.GetAvailablePlace();

        passenger.GetTransform().parent = _passengersParent;
        passenger.TakeEmptyBusCell(availablePlace);

        _passengers.Add(passenger);

        PassegnerAdded?.Invoke();
    }

    private void OnPassegnerZoneExpanded()
    {
        _passengers.ForEach(passenger => passenger.TakeEmptyBusCell(_passengerZone.GetAvailablePlace()));
    }
}
