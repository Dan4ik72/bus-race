using System.Runtime.CompilerServices;
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

    private void Awake()
    {
        _upgradeModel = new BusUpgradeModel(_dataStorageCompositeRoot.PlayerBusDataStorage, _upgradeConfig);
        _upgradePresenter = new BusUpgradePresenter(_upgradeBusFareAmountButtonView, _upgradeBusSpeedButtonView, _upgradeModel);
    }

    private void OnDisable()
    {
        _upgradePresenter.Disable();
    }
}

