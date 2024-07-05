using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> states = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> currentState;
    protected bool isTransitioningState = false;
    // Start is called before the first frame update
    void Start()
    {
        currentState.EnterState();
    }
    // Update is called once per frame
    void Update()
    {
        EState stateKey = currentState.NextState();
        if (!isTransitioningState && stateKey.Equals(currentState.stateKey))
        {
            currentState.UpdateState();
        }
        else if (!isTransitioningState)
        {
            TransitionToState(stateKey);
        }
    }
    public void TransitionToState(EState newState)
    {
        isTransitioningState = true;
        currentState.ExitState();
        currentState = states[newState];
        currentState.EnterState();
        isTransitioningState = false;
    }
}
