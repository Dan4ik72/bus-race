using UnityEngine;

public class FareAmountPresenter
{
    private UITextView _view;
    private FareAmountModel _model;

    public FareAmountPresenter(UITextView view, FareAmountModel model)
    {
        _view = view;
        _model = model;

        Init();
    }

    private void Init()
    {
        UpdateViewText();

        _model.FareAmountChanged += UpdateViewText;
    }

    public void Disable()
    {
        _model.FareAmountChanged -= UpdateViewText;
    }

    private void UpdateViewText()
    {
        _view.ChangeText(_model.CurrentFareAmount.ToString());
    }
}

