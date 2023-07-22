using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTabSetUp : MonoBehaviour
{
    [SerializeField] private DataStorageCompositeRoot _dataCompositeRoot;

    [SerializeField] private ButtonView _playButtonView;
    [SerializeField] private UITextView _playerMoneyView;

    [SerializeField] private ButtonView _rewardedButtonView;

    [SerializeField] private int _gameSceneBuildIndex = 2;

    private ButtonModel _playButtonModel;
    private ButtonPresenter _playButtonPresenter;

    private PlayerMoneyPresenter _playerMoneyPresenter;
    private PlayerMoneyViewModel _playerMoneyViewModel;

    private ButtonPresenter _rewardedButtonPresetner;
    private RewardedButtonModel _rewardedButtonModel;

    public void Start()
    {
        InitStartButton();
        InitPlayerMoneyMVP();
        InitRewardedButton();
    }

    private void InitStartButton()
    {
        _playButtonModel = new LoadSceneButtonModel(_gameSceneBuildIndex);
        _playButtonPresenter = new ButtonPresenter(_playButtonModel, _playButtonView);
    }

    private void InitPlayerMoneyMVP()
    {
        _playerMoneyViewModel = new PlayerMoneyViewModel(_dataCompositeRoot.PlayerMoneyDataStorage.GetData());
        _playerMoneyPresenter = new PlayerMoneyPresenter(_playerMoneyView, _playerMoneyViewModel);
    }

    private void InitRewardedButton()
    {
        _rewardedButtonModel = new RewardedButtonModel(_dataCompositeRoot.PlayerMoneyDataStorage.GetData());
        _rewardedButtonPresetner = new ButtonPresenter(_rewardedButtonModel, _rewardedButtonView);
    }

    private void OnDestroy()
    {
        _playButtonPresenter.Disable();
        _playerMoneyPresenter.Disable();
        _rewardedButtonPresetner.Disable();
    }
}
