using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerBusDataStorageService
{
    private PlayerBusData _playerBusData;
    private BusConfig _busConfig;

    private ISaveService _saveService;

    public PlayerBusDataStorageService(ISaveService saveService, BusConfig budConfig)
    {
        _saveService = saveService;
        _busConfig = budConfig;

        _playerBusData = new PlayerBusData();
        UploadData();
    }

    public void SaveData()
    {
        _saveService.SaveInt(nameof(_playerBusData.FareAmount), _playerBusData.FareAmount);
        _saveService.SaveFloat(nameof(_playerBusData.BusSpeed), _playerBusData.BusSpeed);
    }

    public PlayerBusData GetData()
    {
        return _playerBusData;
    }

    private void UploadData()
    {
        if (_saveService.CheckKeyOnExist(nameof(_playerBusData.FareAmount)) == false)
        {
            _playerBusData.SetBusSpeed(_busConfig.GasSpeed);
            _playerBusData.SetFareAmount(_busConfig.FareAmount);
            SaveData();
            return;
        }

        _playerBusData.SetFareAmount(_saveService.LoadInt(nameof(_playerBusData.FareAmount)));
        _playerBusData.SetBusSpeed(_saveService.LoadFloat(nameof(_playerBusData.BusSpeed)));
    }
}

