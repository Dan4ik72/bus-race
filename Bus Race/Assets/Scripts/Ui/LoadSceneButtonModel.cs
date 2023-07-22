using UnityEngine;

public class LoadSceneButtonModel : ButtonModel
{
    private int _sceneBuildIndex;

    private bool _isLoadWithAdShow;

    private YandexGameAdsHandler _adsHandler;

    public LoadSceneButtonModel(int loadSceneBuildIndex = -1, bool isLoadWithAdShow = false)
    {
        _sceneBuildIndex = loadSceneBuildIndex;
        _isLoadWithAdShow = isLoadWithAdShow;

        _adsHandler = new YandexGameAdsHandler();
    }

    public override void OnButtonClick()
    {
        if (_isLoadWithAdShow)
            _adsHandler.ShowFullSceenAd();

        if (_sceneBuildIndex == -1)
        {
            SceneLoadHandler.Instance.ReloadCurrentScene();
            return;
        }
 
        SceneLoadHandler.Instance.LoadSceneByBuildIndex(_sceneBuildIndex);
            
        base.OnButtonClick();
    }
}
