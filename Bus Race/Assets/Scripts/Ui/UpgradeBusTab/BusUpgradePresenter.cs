using UnityEngine;

public class BusUpgradePresenter
{
    private UpgradeButtonView _fareAmountUpgradeButtonView;
    private UpgradeButtonView _busSpeedUpgradeButtonView;

    private BusUpgradeModel _busUpgradeModel;

    public BusUpgradePresenter(UpgradeButtonView fareAmountUpgradeButtonView, UpgradeButtonView busSpeedUpgradeButtonView, BusUpgradeModel busUpgradeModel)
    {
        _fareAmountUpgradeButtonView = fareAmountUpgradeButtonView;
        _busSpeedUpgradeButtonView = busSpeedUpgradeButtonView;
        _busUpgradeModel = busUpgradeModel;

        Init();
    }

    public void Disable()
    {
        _fareAmountUpgradeButtonView.UpgradeButtonClicked -= _busUpgradeModel.UpgradeFareAmount;
        _busSpeedUpgradeButtonView.UpgradeButtonClicked -= _busUpgradeModel.UpgradeSpeed;

        _busUpgradeModel.FareAmountReachedMaxValue -= _fareAmountUpgradeButtonView.DisableButton;
        _busUpgradeModel.BusSpeedReachedMaxValue -= _busSpeedUpgradeButtonView.DisableButton;

        _busUpgradeModel.BusSpeedValueUpdated -= _busSpeedUpgradeButtonView.ChangeUpgradeValue;
        _busUpgradeModel.FareAmountUpdated -= _fareAmountUpgradeButtonView.ChangeUpgradeValue;
    }

    private void Init()
    {
        _fareAmountUpgradeButtonView.UpgradeButtonClicked += _busUpgradeModel.UpgradeFareAmount;
        _busSpeedUpgradeButtonView.UpgradeButtonClicked += _busUpgradeModel.UpgradeSpeed;

        _busUpgradeModel.BusSpeedValueUpdated += _busSpeedUpgradeButtonView.ChangeUpgradeValue;
        _busUpgradeModel.FareAmountUpdated += _fareAmountUpgradeButtonView.ChangeUpgradeValue;
        
        _busUpgradeModel.FareAmountReachedMaxValue += _fareAmountUpgradeButtonView.DisableButton;
        _busUpgradeModel.BusSpeedReachedMaxValue += _busSpeedUpgradeButtonView.DisableButton;

        _busUpgradeModel.OnValuesUpdated();
    }
}
