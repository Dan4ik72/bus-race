using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishPanelSetUp : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private RectTransform _generalElementsHolder;
    [SerializeField] private Image _loseBackground;
    [SerializeField] private Image _winBackground;
    [SerializeField] private TMP_Text _enemyScore;
    [SerializeField] private TMP_Text _playerScore;
    [SerializeField] private TMP_Text _playerReward;
    [SerializeField] private ButtonView _continueButtonView;

    private LoadSceneButtonModel _continueButtonModel;
    private ButtonPresenter _continueButtonPresenter;

    private BusPassengers _playerBusPassengers;
    private BusPassengers _enemyBusPassengers;
    private BusFarePaymentService _busFarePaymentService;

    private int _mainMenuBuildIndex = 1;

    public void Init(BusPassengers playerBusPassengers, BusPassengers enemyBusPassengers, BusFarePaymentService busFarePaymentService)
    {
        _playerBusPassengers = playerBusPassengers;
        _enemyBusPassengers = enemyBusPassengers; 
        _busFarePaymentService = busFarePaymentService;

        SetUpContinueButton();
    }

    private void SetUpGeneralElements()
    {
        _enemyScore.text = _enemyBusPassengers.Count.ToString();
        _playerScore.text = _playerBusPassengers.Count.ToString();
        _playerReward.text = _busFarePaymentService.CurrentFareAmount.ToString();
    }

    public void EnableWonPanel()
    {
        _winBackground.gameObject.SetActive(true);
        _generalElementsHolder.gameObject.SetActive(true);

        SetUpGeneralElements();
    }

    public void EnableLostPanel()
    {
        _loseBackground.gameObject.SetActive(true);
        _generalElementsHolder.gameObject.SetActive(true);

        SetUpGeneralElements();
    }

    private void SetUpContinueButton()
    {
        _continueButtonModel = new LoadSceneButtonModel(_mainMenuBuildIndex);
        _continueButtonPresenter = new ButtonPresenter(_continueButtonModel, _continueButtonView);
    }

    public void Disable()
    {
        _continueButtonPresenter.Disable();
    }
}

