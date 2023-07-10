using UnityEngine.Events;
using UnityEngine;

public class MainCycleGameState : State
{
    public event UnityAction MainCycleGameStarted;

    public MainCycleGameState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Main Cycle Started");
        MainCycleGameStarted?.Invoke();
    }
}
