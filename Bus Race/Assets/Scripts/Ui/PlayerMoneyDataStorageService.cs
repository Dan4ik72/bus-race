using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoneyDataStorageService
{
    private PlayerMoney _playerMoney;

    private ISaveService _saveService;

    public PlayerMoneyDataStorageService(ISaveService saveService)
    {
        _saveService = saveService;

        _playerMoney = new PlayerMoney();
        UploadData();
    }

    public PlayerMoney GetData() => _playerMoney;

    public void SaveData()
    {
        _saveService.SaveInt(nameof(_playerMoney.PlayerMoneyValue), _playerMoney.PlayerMoneyValue);
    }

    private void UploadData()
    {
        if(_saveService.CheckKeyOnExist(nameof(_playerMoney.PlayerMoneyValue)) == false)
        {
            _playerMoney.SetPlayerMoney(0);
            return;
        }

        _playerMoney.SetPlayerMoney(_saveService.LoadInt(nameof(_playerMoney.PlayerMoneyValue)));
    }
}

