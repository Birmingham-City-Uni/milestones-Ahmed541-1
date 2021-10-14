using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seekState : state
{
    agent owner;

    float seek_for = 5.0f;

    public seekState(agent owner, stateManager sm) : base(owner, sm) { }

    public override void Enter()
    {
        Debug.Log("entering seek state");
        
    }

    public override void Execute()
    {
        Debug.Log("Executing seek state");
        seek_for -= Time.deltaTime;
        if (seek_for <= 0.0f)
        {
            sm.popState();
        }
       
    }

    public override void Exit()
    {
        Debug.Log("Exiting Wander state");
    }
}
