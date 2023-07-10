using UnityEngine;
using UnityEngine.Events;

public class BeginGameState : State
{
    private float _timer = 0;

    public event UnityAction GameBegan;

    public BeginGameState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        GameBegan?.Invoke();
    }

    public override void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < 2)
            return;

        StateMachine.SetState<MainCycleGameState>();
    }
}
