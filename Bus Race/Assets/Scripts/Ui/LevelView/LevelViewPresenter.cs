using UnityEngine;

public class LevelViewPresenter
{
    private UITextView _view;
    private LevelSelectHandler _model;

    public LevelViewPresenter(UITextView view, LevelSelectHandler model)
    {
        _view = view;
        _model = model;

        Init();
    }

    private void Init()
    {
        _model.CurrentLevelChanged += ChangeViewText;

        ChangeViewText(_model.GetCurrentLevel());
    }

    private void ChangeViewText(int newCurrentLevel)
    {
        _view.ChangeText((newCurrentLevel + 1).ToString());
    }

    public void Disable()
    {
        _model.CurrentLevelChanged -= ChangeViewText;
    }
}

