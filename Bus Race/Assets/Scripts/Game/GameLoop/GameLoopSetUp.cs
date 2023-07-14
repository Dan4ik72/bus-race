using UnityEngine.Events;
using UnityEngine;

public class GameLoopSetUp
{
    private StateMachine _stateMachine;

    private GameEndingTrigger _gameEndingTrigger;

    private BeginGameState _beginGameState;
    private MainCycleGameState _mainCycleGameState;
    private EndingGameState _endingGameState;

    public event UnityAction GameBegan;
    public event UnityAction MainGameCycleStarted;
    public event UnityAction GameEndingStateStarted;

    public GameLoopSetUp(GameEndingTrigger gameEndingTrigger)
    {
        SetStateMachineUp();
        _gameEndingTrigger = gameEndingTrigger;

        _gameEndingTrigger.BusArrived += SetEndingGameState;
    }

    private void SetBegingGameState() 
    {
        _stateMachine.SetState<BeginGameState>();
        GameBegan?.Invoke();
    }

    private void SetEndingGameState()
    {
        _stateMachine.SetState<EndingGameState>();
        GameEndingStateStarted?.Invoke();

        _gameEndingTrigger.BusArrived -= SetEndingGameState;
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
        _endingGameState.EndingGameStarted += () => GameEndingStateStarted?.Invoke();

        _stateMachine.AddState(_beginGameState);
        _stateMachine.AddState(_mainCycleGameState);
        _stateMachine.AddState(_endingGameState);

        SetBegingGameState();
    }
}