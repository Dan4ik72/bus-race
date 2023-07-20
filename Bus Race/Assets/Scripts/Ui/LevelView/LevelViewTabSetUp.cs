using UnityEngine;

public class LevelViewTabSetUp : MonoBehaviour
{
    [SerializeField] private DataStorageCompositeRoot _dataStorageCompositeRoot;
    [SerializeField] private UITextView _view;

    private LevelViewPresenter _presenter;
    private LevelSelectHandler _model;

    public void Start()
    {
        _model = _dataStorageCompositeRoot.LevelsDataStorageService.LevelSelectHandler;

        _presenter = new LevelViewPresenter(_view, _model);
    }

    public void OnDisable()
    {
        _presenter.Disable();
    }
}
