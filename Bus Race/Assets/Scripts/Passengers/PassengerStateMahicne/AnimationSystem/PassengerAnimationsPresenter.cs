public class PassengerAnimationsPresenter
{
    private PassengerAnimationsHandler _handler;

    private WaitingForBusState _waitingState;
    private GoingToBusState _goingToBusState;
    private TakeEmptyBusCellState _takeEmtyBusCellState;
    private RidingOnBusState _ridingOnBusState;

    public PassengerAnimationsPresenter(PassengerAnimationsHandler handler, WaitingForBusState waitingState, GoingToBusState goingToBusState, TakeEmptyBusCellState takeEmtyBusCellState, RidingOnBusState ridingOnBusState)
    {
        _handler = handler;
        _waitingState = waitingState;
        _goingToBusState = goingToBusState;
        _takeEmtyBusCellState = takeEmtyBusCellState;
        _ridingOnBusState = ridingOnBusState;

        SubscribeAnimationsHandlerOnStateEvents();
    }

    private void SubscribeAnimationsHandlerOnStateEvents()
    {
        _waitingState.WaitingBusStateEntered += _handler.PlayWavingAnimation;
        _goingToBusState.GoingToBusStateEntered += _handler.PlayRunningAnimation;
        _takeEmtyBusCellState.TakeEmptyBusCellStateEntered += _handler.PlayRunningAnimation;
        _ridingOnBusState.RidingOnBusStateEntered += _handler.PlayIdleAnimation;
    }

    public void UnsubscribeAnimationsHandlerOnStateEvents()
    {
        _waitingState.WaitingBusStateEntered -= _handler.PlayWavingAnimation;
        _goingToBusState.GoingToBusStateEntered -= _handler.PlayRunningAnimation;
        _takeEmtyBusCellState.TakeEmptyBusCellStateEntered -= _handler.PlayRunningAnimation;
        _ridingOnBusState.RidingOnBusStateEntered -= _handler.PlayIdleAnimation;
    }
}
