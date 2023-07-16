using UnityEngine;

public class ButtonPresenter
{
    private ButtonModel _model;
    private ButtonView _view;

    public ButtonPresenter(ButtonModel model, ButtonView view)
    {
        _model = model;
        _view = view;

        Init();
    }

    public void Disable()
    {
        _view.OnClick -= _model.OnButtonClick;
    }

    private void Init()
    {
        _view.OnClick += _model.OnButtonClick;
    }
}
