using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTabSetUp : MonoBehaviour
{
    [SerializeField] private ButtonView _playButtonView;
    [SerializeField] private ButtonView _upgradeButtonView;
    [SerializeField] private TabSwitcher _tabSwitcher;

    private ButtonModel _playButtonModel;
    private ButtonModel _upgradeButtonModel;

    private ButtonPresenter _playButtonPresenter;
    private ButtonPresenter _upgradeButtonPresenter;

    public ButtonModel PlayButtoonModel => _playButtonModel;
    public ButtonModel UpgradeButtonModel => _upgradeButtonModel;

    //All of this have to be inited in the ui composite root instead awake
    public void Awake()
    {
        InitStartButton();
        InitUpgradeButton();
    }

    private void InitStartButton()
    {
        _playButtonModel = new LoadSceneButtonModel();
        _playButtonPresenter = new ButtonPresenter(_playButtonModel, _playButtonView);

    }

    private void InitUpgradeButton()
    {
        _upgradeButtonModel = new UITabSwitchButtonModel(_tabSwitcher);
        _upgradeButtonPresenter = new ButtonPresenter(_upgradeButtonModel, _upgradeButtonView);
    }

    private void OnDisable()
    {
        _playButtonPresenter.Disable();
        _upgradeButtonPresenter.Disable();
    }
}
