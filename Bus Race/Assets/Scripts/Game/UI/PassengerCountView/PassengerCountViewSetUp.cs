public class PassengerCountViewSetUp
{
    private UITextView _view;
    private PassengerCountModel _model;
    private UIPassengerCountTextPresenter _presenter;

    public PassengerCountViewSetUp(UITextView view, BusPassengers busPassengers)
    {
        _view = view;
        _model = new PassengerCountModel(busPassengers);
        _presenter = new UIPassengerCountTextPresenter(_view, _model);
    }

    public void Disable()
    {
        _presenter.Disable();
    }
}

