using UnityEngine.Events;

public class EndingGameState : State
{
    public event UnityAction EndingGameStarted;

    public EndingGameState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        EndingGameStarted?.Invoke();
    }
}
