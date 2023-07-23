public class RewardedButtonModel : ButtonModel
{
    private PlayerMoneyDataStorageService _playerMoneyDataStorageService;
    private YandexGameAdsHandler _adsHandler;

    private int _rewardAmount = 150;

    public RewardedButtonModel(PlayerMoneyDataStorageService playerMoneyDataStorageService)
    {
        _adsHandler = new YandexGameAdsHandler();

        _playerMoneyDataStorageService = playerMoneyDataStorageService;
    }

    public override void OnButtonClick()
    {
        _adsHandler.ShowRewarded();

        _adsHandler.RewardedShown += OnRewardedComplete;
    }

    private void OnRewardedComplete()
    {
        _playerMoneyDataStorageService.GetData().AddMoney(_rewardAmount);
        _playerMoneyDataStorageService.SaveData();

        _adsHandler.RewardedShown -= OnRewardedComplete;
    }
}