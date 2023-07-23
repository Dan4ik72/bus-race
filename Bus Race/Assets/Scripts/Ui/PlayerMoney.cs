using UnityEngine.Events;

public class PlayerMoney
{
    private int _value;

    public int PlayerMoneyValue => _value;

    public event UnityAction<int> ValueChanged;

    public void SetPlayerMoney(int value)
    {
        if (value < 0)
            throw new System.ArgumentOutOfRangeException(nameof(value));

        _value = value;

        ValueChanged?.Invoke(value);
    }

    public void AddMoney(int value) 
    {
        if(value < 0)
            throw new System.AccessViolationException(nameof(value));

        _value += value;

        ValueChanged?.Invoke(_value);
    }

    public bool TrySpendMoney(int price)
    {
        if (price < 0)
            throw new System.ArgumentOutOfRangeException(nameof(price));

        if (price > _value)
            return false;

        _value -= price;

        ValueChanged?.Invoke(_value);

        return true;
    }
}
