public class GameMenuUISetUp
{
    private ButtonView _mainMenuButtonView;
    private ButtonView _restartButtonView;

    private ButtonPresenter _mainMenuButtonPresenter;
    private LoadSceneButtonModel _loadMainMenuSceneButtonModel;
    
    private ButtonPresenter _reloadLevelButtonPresenter;
    private LoadSceneButtonModel _reloadLevelButtonButtonModel;

    private int _mainMenuSceneIndex;

    public GameMenuUISetUp(ButtonView mainMenuButtonView, ButtonView restartButtonView, int mainMenuSceneIndex)
    {
        _mainMenuButtonView = mainMenuButtonView;
        _restartButtonView = restartButtonView;

        _mainMenuSceneIndex = mainMenuSceneIndex;

        InitMainMenuButtonMVP();
        InitReloadLevelMVP();
    }
    
    private void InitMainMenuButtonMVP()
    {
        _loadMainMenuSceneButtonModel = new LoadSceneButtonModel(_mainMenuSceneIndex);
        _mainMenuButtonPresenter = new ButtonPresenter(_loadMainMenuSceneButtonModel, _mainMenuButtonView);
    }

    private void InitReloadLevelMVP()
    {
        _reloadLevelButtonButtonModel = new LoadSceneButtonModel(-1);
        _reloadLevelButtonPresenter = new ButtonPresenter(_reloadLevelButtonButtonModel, _restartButtonView);
    }

    public void Disable()
    {
        _mainMenuButtonPresenter.Disable();
        _reloadLevelButtonPresenter.Disable();
    }
}
