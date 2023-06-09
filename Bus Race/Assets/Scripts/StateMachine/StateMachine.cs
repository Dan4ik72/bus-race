using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Dictionary<Type, State> _states = new Dictionary<Type, State>();

    private State _currentState;

    public void AddState(State newState)
    {
        _states.Add(newState.GetType(), newState);
    }

    public void SetState<T>() where T : State
    {
        var type = typeof(T);

        if(_currentState == null && _states.TryGetValue(type, out State state))
        {
            _currentState = state;
            _currentState.Enter();
            return;
        }

        if (_currentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out State newState))
        {
            _currentState.Exit();

            _currentState = newState;

            _currentState.Enter();
        }
    }

    public void Update()
    {
        if (_currentState != null)
            _currentState.Update();
    }
}
