using UnityEngine;

public class UpgradeBusTabSetUp : MonoBehaviour
{
    [SerializeField] private UpgradeButtonView _upgradeBusSpeedButtonView;
    [SerializeField] private UpgradeButtonView _upgradeBusFareAmountButtonView;

    [SerializeField] private BusUpgradeConfig _upgradeConfig;

    //temporary code
    [SerializeField] private DataStorageCompositeRoot _dataStorageCompositeRoot;

    private BusUpgradeModel _upgradeModel;
    private BusUpgradePresenter _upgradePresenter;

    private ButtonPresenter _returnButtonPresenter;

    private void Awake()
    {
        InitUpgradeButtons();
    }

    private void InitUpgradeButtons()
    {
        _upgradeModel = new BusUpgradeModel(_dataStorageCompositeRoot.PlayerBusDataStorage, _dataStorageCompositeRoot.PlayerMoneyDataStorage, _upgradeConfig);
        _upgradePresenter = new BusUpgradePresenter(_upgradeBusFareAmountButtonView, _upgradeBusSpeedButtonView, _upgradeModel);
    }

    private void OnDestroy()
    {
        _upgradePresenter.Disable();
    }
}