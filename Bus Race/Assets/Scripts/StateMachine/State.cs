using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected readonly StateMachine StateMachine;

    public State(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }
}
