public class RewardedButtonModel : ButtonModel
{
    private PlayerMoney _playerMoney;
    private YandexGameAdsHandler _adsHandler;

    private int _rewardAmount = 150;

    public RewardedButtonModel(PlayerMoney playerMoney)
    {
        _adsHandler = new YandexGameAdsHandler();
        _playerMoney = playerMoney;
    }

    public override void OnButtonClick()
    {
        _adsHandler.ShowRewarded();

        _adsHandler.RewardedShown += OnRewardedComplete;
    }

    private void OnRewardedComplete()
    {
        _playerMoney.AddMoney(_rewardAmount);

        _adsHandler.RewardedShown -= OnRewardedComplete;
    }
}