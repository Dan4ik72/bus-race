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
    }

    private void Init()
    {
        _fareAmountUpgradeButtonView.UpgradeButtonClicked += _busUpgradeModel.UpgradeFareAmount;
        _busSpeedUpgradeButtonView.UpgradeButtonClicked += _busUpgradeModel.UpgradeSpeed;
    }
}
