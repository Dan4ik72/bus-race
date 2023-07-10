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
        _dataStorageService.GetData().SetBusSpeed(_config.BusSpeedValueIncreaseStep);
        _dataStorageService.SaveData();
    }

    public void UpgradeFareAmount()
    {
        _dataStorageService.GetData().SetFareAmount(_config.FareAmountIncreaseStep);
        _dataStorageService.SaveData();
    }
}
