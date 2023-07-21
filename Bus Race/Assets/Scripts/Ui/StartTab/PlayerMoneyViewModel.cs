using UnityEngine.Events;
using UnityEngine;

public class PlayerMoneyViewModel
{
    private PlayerMoney _playerMoney;

    public event UnityAction MoneyChanged;

    public int PlayerMoney => _playerMoney.PlayerMoneyValue;

    public PlayerMoneyViewModel(PlayerMoney playerMoney)
    {
        _playerMoney = playerMoney;

        _playerMoney.ValueChanged += OnPlayerMoneyValueChanged;
    }

    private void OnPlayerMoneyValueChanged(int newValue)
    {
        MoneyChanged?.Invoke();
    }
}

