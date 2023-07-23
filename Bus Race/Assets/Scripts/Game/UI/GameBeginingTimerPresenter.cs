public class GameBeginingTimerPresenter
{
    private UITextView _view;
    private GameBeginingTimerModel _model;

    public GameBeginingTimerPresenter(GameBeginingTimerModel model, UITextView view)
    {
        _model = model;
        _view = view;

        Init();
    }

    private void Init()
    {
        _model.ValueChanged += ChangeViewText;
        _model.TimerStarted += EnableTextView;
        _model.TimerEnded += DisableViewText;
    }

    private void ChangeViewText(int newValue)
    {
        _view.ChangeText(newValue.ToString());
    }

    private void EnableTextView()
    {
        _view.gameObject.SetActive(true);
    }

    private void DisableViewText()
    {
        _view.gameObject.SetActive(false);
    }

    public void Disable()
    {
        _model.ValueChanged -= ChangeViewText;
        _model.TimerEnded -= DisableViewText;
    }
}
