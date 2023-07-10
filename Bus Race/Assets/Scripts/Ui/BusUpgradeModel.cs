public class BusUpgradeModel
{
    private PlayerBusDataStorageService _dataStorageService;

    private BusUpgradeConfig _config;

    public BusUpgradeModel(PlayerBusDataStorageService dataStorageService, BusUpgradeConfig config)
    {
        _dataStorageService = dataStorageService;
        _config = config;
    }

    public void UpgradeSpeed()
    {
        var data = _dataStorageService.GetData();

        data.SetBusSpeed(data.BusSpeed + _config.BusSpeedValueIncreaseStep);
        _dataStorageService.SaveData();
    }

    public void UpgradeFareAmount()
    {
        var data = _dataStorageService.GetData();

        _dataStorageService.SaveData();
    }
}
