using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BeginGameState : State
{
    private WaitForSecondsRealtime _startGameDelay = new WaitForSecondsRealtime(4f);

    public event UnityAction GameBegan;

    public BeginGameState(StateMachine stateMachine) : base(stateMachine) { }
    
    public override void Enter()
    {
        GameBegan?.Invoke();

        Coroutines.StartRoutine(StartDelay());
    }
     
    private IEnumerator StartDelay()
    {
        yield return _startGameDelay;

        StateMachine.SetState<MainCycleGameState>();
    }
}
