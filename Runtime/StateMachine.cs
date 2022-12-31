using System;
using System.Collections.Generic;

public class StateMachine
{
    public Dictionary<string, IState> States = new();
    public IState CurrentState;

    public virtual void Tick()
    {
        CurrentState?.Tick();
    }

    public virtual void FixedTick()
    {
        CurrentState?.FixedTick();
    }

    public void AddState(string key, IState state)
    {
        States.Add(key, state);
    }

    public void SetState(string key)
    {
        if (States.TryGetValue(key, out IState state))
        {
            if (state == CurrentState)
                return;

            CurrentState?.OnExit();
            CurrentState = state;
            CurrentState.OnEnter();
        }
        else
        {
            throw new ArgumentException("Invalid state key.");
        }
    }
}