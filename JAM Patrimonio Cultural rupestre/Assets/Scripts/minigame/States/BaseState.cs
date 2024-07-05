using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState<EState>: MonoBehaviour where EState : Enum
{
    public BaseState(EState key)
    {
        stateKey = key;
    }
    public EState stateKey { get; private set; }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState NextState();
}
