public class UIPassengerCountTextPresenter
{
    private UITextView _view;
    private PassengerCountModel _model;

    public UIPassengerCountTextPresenter(UITextView view, PassengerCountModel model)
    {
        _view = view;
        _model = model;

        Init();
    }

    private void Init()
    {
        _view.ChangeText(_model.PassengerCount.ToString());

        _model.PassengerCountChanged += UpdateView;
    }

    public void Disable()
    {
        _model.PassengerCountChanged -= UpdateView;
    }

    private void UpdateView()
    {
        _view.ChangeText(_model.PassengerCount.ToString());
    }
}
