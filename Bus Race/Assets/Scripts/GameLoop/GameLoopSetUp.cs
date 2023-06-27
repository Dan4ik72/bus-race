using UnityEngine.Events;

public class GameLoopSetUp
{
    private StateMachine _stateMachine;

    private BeginGameState _beginGameState;
    private MainCycleGameState _mainCycleGameState;
    private EndingGameState _endingGameState;

    public event UnityAction GameBegan;
    public event UnityAction MainGameCycleStarted;
    public event UnityAction GameEndingStarted;

    public GameLoopSetUp()
    {
        SetStateMachineUp();
    }

    public void SetBegingGameState() 
    {
        _stateMachine.SetState<BeginGameState>();
        GameBegan?.Invoke();
    }

    public void Update()
    {
        _stateMachine.Update();
    }

    private void SetStateMachineUp()
    {
        _stateMachine = new StateMachine();

        _beginGameState = new BeginGameState( _stateMachine);
        _mainCycleGameState = new MainCycleGameState(_stateMachine);
        _endingGameState = new EndingGameState(_stateMachine);

        _beginGameState.GameBegan += () => GameBegan?.Invoke();
        _mainCycleGameState.MainCycleGameStarted += () => MainGameCycleStarted?.Invoke();
        _endingGameState.EndingGameStarted += () => GameEndingStarted?.Invoke();

        _stateMachine.AddState(_beginGameState);
        _stateMachine.AddState(_mainCycleGameState);
        _stateMachine.AddState(_endingGameState);

        SetBegingGameState();
    }
}