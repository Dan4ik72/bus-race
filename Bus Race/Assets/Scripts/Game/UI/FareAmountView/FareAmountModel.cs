using UnityEngine;
using UnityEngine.Events;

public class FareAmountModel
{
    private BusFarePaymentService _busFarePaymentService;

    private int _currentFareAmount = 0;

    public event UnityAction FareAmountChanged;

    public FareAmountModel(BusFarePaymentService busFarePaymentService) 
    {
        _busFarePaymentService = busFarePaymentService;

        _busFarePaymentService.PassengerPaidFare += UpdateFareAmount;
    }

    public int CurrentFareAmount => _currentFareAmount;

    private void UpdateFareAmount()
    {
        _currentFareAmount = _busFarePaymentService.CurrentFareAmount;

        FareAmountChanged?.Invoke();
    }
}

