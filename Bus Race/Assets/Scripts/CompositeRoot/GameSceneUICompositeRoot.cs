using UnityEngine;
using UnityEngine.UI;

public class GameSceneUICompositeRoot : CompositeRoot
{
    [Header("Composite Roots")]
    [SerializeField] private PlayerBusCompositeRoot _playerBusCompositeRoot;
    [SerializeField] private EnemyBusCompositeRoot _enemyBusCompositRoot;
    [SerializeField] private GameCompositeRoot _gameCompositeRoot;

    [Header("Passenger Count view")]
    [SerializeField] private UITextView _playerPassengerCountView;
    [SerializeField] private UITextView _enemyPassengerCountView;

    [Header("FareAmountView")]
    [SerializeField] private UITextView _fareAmountViewText;

    [Header("Home and Restart Buttons view")]
    [SerializeField] private ButtonView _homeButtonView;
    [SerializeField] private ButtonView _restartButtonView;

    [Header("Ending panel")]
    [SerializeField] GameFinishPanelSetUp _gameFinishPanelSetUp;
    
    private PassengerCountViewSetUp _playerPassengerCountViewSetUp;
    private PassengerCountViewSetUp _enemyPassengerCountViewSetUp;

    private FareAmountViewSetUp _fareAmountViewSetUp;

    private GameMenuUISetUp _gameMenuUISetUp;


    public override void Compose()
    {
        _playerPassengerCountViewSetUp = new PassengerCountViewSetUp(_playerPassengerCountView, _playerBusCompositeRoot.Passengers);
        _enemyPassengerCountViewSetUp = new PassengerCountViewSetUp(_enemyPassengerCountView, _enemyBusCompositRoot.BusPassenger);

        _fareAmountViewSetUp = new FareAmountViewSetUp(_fareAmountViewText, _playerBusCompositeRoot.BusFarePaymentService);

        _gameMenuUISetUp = new GameMenuUISetUp(_homeButtonView, _restartButtonView, 1);

        _gameFinishPanelSetUp.Init(_playerBusCompositeRoot.Passengers, _enemyBusCompositRoot.BusPassenger, _playerBusCompositeRoot.BusFarePaymentService);
        _gameCompositeRoot.GameEndingHandler.PlayerWon += _gameFinishPanelSetUp.EnableWonPanel;
        _gameCompositeRoot.GameEndingHandler.PlayerLost += _gameFinishPanelSetUp.EnableLostPanel;

    }

    private void OnDisable()
    {
        _playerPassengerCountViewSetUp.Disable();
        _enemyPassengerCountViewSetUp.Disable();

        _fareAmountViewSetUp.Disable();
        _gameMenuUISetUp.Disable();

        _gameCompositeRoot.GameEndingHandler.PlayerWon -= _gameFinishPanelSetUp.EnableWonPanel;
        _gameCompositeRoot.GameEndingHandler.PlayerLost -= _gameFinishPanelSetUp.EnableLostPanel;
    }
}
