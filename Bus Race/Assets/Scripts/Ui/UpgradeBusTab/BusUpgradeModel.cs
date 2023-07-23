using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class BusUpgradeModel
{   
    private PlayerBusDataStorageService _busDataStorageService;

    private PlayerMoneyDataStorageService _playerMoneyDataStorageService;

    private BusUpgradeConfig _config;

    public event UnityAction<int, int> FareAmountUpdated;
    public event UnityAction<int, int> BusSpeedValueUpdated;

    public event UnityAction FareAmountReachedMaxValue;
    public event UnityAction BusSpeedReachedMaxValue;

    public event UnityAction DisabledAbilityToUpgradeFareAmount;
    public event UnityAction DisableAbilityToUpgradeBusSpeed;

    public event UnityAction EnableAbilityToUpgradeFareAmount;
    public event UnityAction EnableAbilityToUpgradeBusSpeed;

    public BusUpgradeModel(PlayerBusDataStorageService dataStorageService, PlayerMoneyDataStorageService playerMoneyDataStorageService, BusUpgradeConfig config)
    {
        _busDataStorageService = dataStorageService;
        _playerMoneyDataStorageService = playerMoneyDataStorageService;
        _config = config;

        _playerMoneyDataStorageService.GetData().ValueChanged += CheckAvailableToBuyUpgradeFareAmount;
        _playerMoneyDataStorageService.GetData().ValueChanged += CheckAvailableToBuyUpgradeSpeed;
    }

    public void OnValuesUpdated()
    {   
        FareAmountUpdated?.Invoke(_busDataStorageService.GetData().FareAmount, _busDataStorageService.GetData().FareAmount * _config.FareAmountIncreasePriceMultiplier);
        BusSpeedValueUpdated?.Invoke((int)_busDataStorageService.GetData().BusSpeed / 7, (int)_busDataStorageService.GetData().BusSpeed * _config.BusSpeedPriceIncreaseMultiplier);

        CheckFareAmountMaxValue(_busDataStorageService.GetData());
        CheckBusSpeedMaxValue(_busDataStorageService.GetData());

        CheckAvailableToBuyUpgradeFareAmount(_playerMoneyDataStorageService.GetData().PlayerMoneyValue);
        CheckAvailableToBuyUpgradeSpeed(_playerMoneyDataStorageService.GetData().PlayerMoneyValue);
    }

    public void UpgradeSpeed()
    {
        var data = _busDataStorageService.GetData();

        if (CheckBusSpeedMaxValue(data) == false)
            return;

        if (_playerMoneyDataStorageService.GetData().TrySpendMoney((int)data.BusSpeed * _config.BusSpeedPriceIncreaseMultiplier) == false)
            return;

        data.SetBusSpeed(data.BusSpeed + _config.BusSpeedValueIncreaseStep);
        _busDataStorageService.SaveData();
        _playerMoneyDataStorageService.SaveData();

        BusSpeedValueUpdated?.Invoke((int)data.BusSpeed / 7, (int)data.BusSpeed * _config.BusSpeedPriceIncreaseMultiplier);

        CheckAvailableToBuyUpgradeSpeed(_playerMoneyDataStorageService.GetData().PlayerMoneyValue);
    }

    public void UpgradeFareAmount()
    {
        var data = _busDataStorageService.GetData();

        if (CheckFareAmountMaxValue(data) == false)
            return;

        if (_playerMoneyDataStorageService.GetData().TrySpendMoney(data.FareAmount * _config.FareAmountIncreasePriceMultiplier) == false)
            return;

        data.SetFareAmount(data.FareAmount + _config.FareAmountIncreaseStep);
        _busDataStorageService.SaveData();
        _playerMoneyDataStorageService.SaveData();

        FareAmountUpdated?.Invoke(data.FareAmount, data.FareAmount * _config.FareAmountIncreasePriceMultiplier);

        CheckAvailableToBuyUpgradeFareAmount(_playerMoneyDataStorageService.GetData().PlayerMoneyValue);
    }

    private bool CheckBusSpeedMaxValue(PlayerBusData data)
    {
        if (data.BusSpeed + _config.BusSpeedValueIncreaseStep > _config.MaxBusSpeed)
        {
            BusSpeedReachedMaxValue?.Invoke();
            return false;
        }

        return true;
    }

    private bool CheckFareAmountMaxValue(PlayerBusData data)
    {
        if (data.FareAmount + _config.FareAmountIncreaseStep > _config.MaxFareAmount)
        {
            FareAmountReachedMaxValue?.Invoke();
            return false;
        }

        return true;
    }

    private void CheckAvailableToBuyUpgradeFareAmount(int newValue)
    {
        if (newValue < _busDataStorageService.GetData().FareAmount * _config.FareAmountIncreasePriceMultiplier)
            DisabledAbilityToUpgradeFareAmount?.Invoke();
        else
            EnableAbilityToUpgradeFareAmount?.Invoke();
    }

    private void CheckAvailableToBuyUpgradeSpeed(int newValue)
    {
        if (newValue < (int)_busDataStorageService.GetData().BusSpeed * _config.BusSpeedPriceIncreaseMultiplier)
            DisableAbilityToUpgradeBusSpeed?.Invoke();
        else
            EnableAbilityToUpgradeBusSpeed?.Invoke();
    }
}