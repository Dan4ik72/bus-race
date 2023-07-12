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
    private BusFarePaymentService _busFarePaymentService;

    public event UnityAction PassegnerAdded;

    public BusPassengers(Transform passengersParent, BusPassengerZone passegnerZone, BusFarePaymentService busFarePaymentService)
    {
        _passengersParent = passengersParent;
        _passengerZone = passegnerZone;

        _passengerZone.GridExpanded += OnPassegnerZoneExpanded;
        _busFarePaymentService = busFarePaymentService;
    }

    public Transform PassengersParent => _passengersParent;

    public void AddPassegner(IPassengerSetUp passenger)
    {
        Transform availablePlace = _passengerZone.GetAvailablePlace();

        passenger.GetTransform().parent = _passengersParent;
        passenger.SetTakeBusCellState(availablePlace);

        _passengers.Add(passenger);

        _busFarePaymentService.PayFare();

        PassegnerAdded?.Invoke();
    }

    public void DoActionForEachPassenger(Action<IPassengerSetUp> action)
    {
        _passengers.ForEach(action);
    }

    private void OnPassegnerZoneExpanded()
    {
        DoActionForEachPassenger(passenger => passenger.SetTakeBusCellState(_passengerZone.GetAvailablePlace()));
    }
}
