using UnityEngine.Events;

public class BusFarePaymentService
{
    private PlayerMoneyDataStorageService _playerMoneyDataStorageService;

    private PlayerBusData _playerBusData;

    public event UnityAction PassengerPaidFare;

    private int _currentFareAmount = 0;

    public BusFarePaymentService(PlayerMoneyDataStorageService playerMoneyDataStorageService, PlayerBusData playerBusData)
    {
        _playerMoneyDataStorageService = playerMoneyDataStorageService;
        _playerBusData = playerBusData;
    }

    public int CurrentFareAmount => _currentFareAmount;

    public void PayFare()
    {
        _currentFareAmount += _playerBusData.FareAmount;
        PassengerPaidFare?.Invoke();
    }

    public void OnGameFinished()
    {
        _playerMoneyDataStorageService.GetData().SetPlayerMoney(_currentFareAmount);
        _playerMoneyDataStorageService.SaveData();
    }
}
