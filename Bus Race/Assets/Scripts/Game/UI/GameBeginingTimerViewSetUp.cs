public partial class GameBeginingTimerViewSetUp
{
    private GameCompositeRoot _gameCompositeRoot;

    private UITextView _timerView;
    private GameBeginingTimerPresenter _timerPresetner;
    private GameBeginingTimerModel _timerModel;

    public GameBeginingTimerViewSetUp(GameCompositeRoot gameCompositeRoot, UITextView gameBeginingTimerView)
    {
        _gameCompositeRoot = gameCompositeRoot;
        _timerView = gameBeginingTimerView;

        InitGameBeginingTimer();
    }

    private void InitGameBeginingTimer()
    {
        _timerModel = new GameBeginingTimerModel(_gameCompositeRoot.GameLoopSetUp);
        _timerPresetner = new GameBeginingTimerPresenter(_timerModel, _timerView);
    }

    public void Disable()
    {
        _timerPresetner.Disable();
    }
}
