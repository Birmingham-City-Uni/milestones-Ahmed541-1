using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class state
{
    protected agent agent;

    protected stateManager sm;

    protected state(agent _agent, stateManager _sm)
    {

        this.agent = _agent;
        this.sm = _sm;
    }
    public abstract void Enter();

    public abstract void Execute();

    public abstract void Exit();

}
