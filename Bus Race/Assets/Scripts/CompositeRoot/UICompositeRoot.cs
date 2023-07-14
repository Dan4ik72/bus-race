using UnityEngine;

public class UICompositeRoot : CompositeRoot
{
    [Header("Composite Roots")]
    [SerializeField] private PlayerBusCompositeRoot _playerBusCompositeRoot;
    [SerializeField] private EnemyBusCompositeRoot _enemyBusCompositRoot;

    [Header("Passenger Count view")]
    [SerializeField] private UITextView _playerPassengerCountView;
    [SerializeField] private UITextView _enemyPassengerCountView;

    [Header("FareAmountView")]
    [SerializeField] private UITextView _fareAmountViewText;

    private PassengerCountViewSetUp _playerPassengerCountViewSetUp;
    private PassengerCountViewSetUp _enemyPassengerCountViewSetUp;

    private FareAmountViewSetUp _fareAmountViewSetUp;

    public override void Compose()
    {
        _playerPassengerCountViewSetUp = new PassengerCountViewSetUp(_playerPassengerCountView, _playerBusCompositeRoot.Passengers);
        _enemyPassengerCountViewSetUp = new PassengerCountViewSetUp(_enemyPassengerCountView, _enemyBusCompositRoot.BusPassenger);

        _fareAmountViewSetUp = new FareAmountViewSetUp(_fareAmountViewText, _playerBusCompositeRoot.BusFarePaymentService);
    }

    private void OnDisable()
    {
        _playerPassengerCountViewSetUp.Disable();
        _enemyPassengerCountViewSetUp.Disable();

        _fareAmountViewSetUp.Disable();
    }
}
