using UnityEngine;

public class PlayerMoneyPresenter
{
    private UITextView _view;
    private PlayerMoneyViewModel _model;

    public PlayerMoneyPresenter(UITextView view, PlayerMoneyViewModel model)
    {
        _view = view;
        _model = model;

        Init();
    }

    private void Init()
    {
        ChangePlayerMoney();

        _model.MoneyChanged += ChangePlayerMoney;
    }

    public void Disable()
    {
        _model.MoneyChanged -= ChangePlayerMoney;
    }

    private void ChangePlayerMoney()
    {
        _view.ChangeText(_model.PlayerMoney.ToString());
    }
}

