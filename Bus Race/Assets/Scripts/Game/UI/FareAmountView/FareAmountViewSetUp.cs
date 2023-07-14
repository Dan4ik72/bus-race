using UnityEngine;

public class FareAmountViewSetUp
{
    private UITextView _view;
    private FareAmountPresenter _presenter;
    private FareAmountModel _model;

    private BusFarePaymentService _busFarePaymentService;

    public FareAmountViewSetUp(UITextView view, BusFarePaymentService busFarePaymentService)
    {
        _view = view;
        _busFarePaymentService = busFarePaymentService;

        _model = new FareAmountModel(_busFarePaymentService);
        _presenter = new FareAmountPresenter(_view, _model);
    }

    public void Disable()
    {
        _presenter.Disable();
    }
}

