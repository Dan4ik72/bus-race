using UnityEngine.Events;

public class WaitingForBusState : BusInteractionState
{
    private float _maxDistanceToBusTrigger;

    private DefaultPassengerSetUp _passenger;

    public event UnityAction WaitingBusStateEntered;

    public WaitingForBusState(StateMachine stateMachine, DefaultPassengerSetUp passenger, float maxDistanceToBusTrigger) : base(stateMachine, passenger.transform)
    {
        _maxDistanceToBusTrigger = maxDistanceToBusTrigger;
        _passenger = passenger;
    }
    
    public override void Enter()
    {
        WaitingBusStateEntered?.Invoke();
    }
}
