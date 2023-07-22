using UnityEngine.Events;
using YG;
using YG.Example;

public class YandexGameAdsHandler 
{
    private int _playerMoneyId = 0;

    public event UnityAction RewardedShown;

    public YandexGameAdsHandler() 
    {
        if (YandexGame.SDKEnabled == false)
            throw new System.InvalidOperationException("Yandex SDK isn't available");

        YandexGame.RewardVideoEvent += OnRewardedShown;
    } 
    
    public void ShowFullSceenAd()
    {
        YandexGame.FullscreenShow();
    }

    public void ShowRewarded()
    {
        YandexGame.RewVideoShow(_playerMoneyId);
    }

    private void OnRewardedShown(int id)
    {
        if (id == _playerMoneyId)
            RewardedShown?.Invoke();
    }
}
